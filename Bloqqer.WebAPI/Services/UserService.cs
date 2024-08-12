using Bloqqer.Application.Exceptions;
using Bloqqer.Domain.Models;
using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Bloqqer.WebAPI.Services;

public sealed class UserService(
    IUnitOfWork _unitOfWork,
    IHttpContextAccessor _httpContextAccessor,
    IEmailService _emailService,
    UserManager<ApplicationUser> _userManager,
    SignInManager<ApplicationUser> _signInManager
) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor = _httpContextAccessor;
    private readonly IEmailService _emailService = _emailService;
    private readonly UserManager<ApplicationUser> _userManager = _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = _signInManager;

    public Guid GetLoggedInUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        bool isValidGuid = Guid.TryParse(userId, out Guid userGuid);
        return isValidGuid
            ? userGuid
            : throw new UnauthorizedException("User is not logged in");
    }

    public async Task<ApplicationUser> GetLoggedInUser()
    {
        var userId = GetLoggedInUserId();

        var user = await _unitOfWork.ApplicationUsers.SingleOrDefaultAsync(a => a.Id == userId)
            ?? throw new NotFoundException($"User with Id ({userId}) was not found");

        return user;
    }

    public async Task<ApplicationUser> GetUserByUserId(Guid userId)
    {
        return await _unitOfWork.ApplicationUsers.GetByIdAsync(userId)
            ?? throw new NotFoundException($"User with Id ({userId}) was not found");
    }

    public async Task<Guid> RegisterUser(RegisterUserDTO registerUserDTO)
    {
        // TODO: Check if the user with the same email/userName already exists? How to prevent registrering the same user? Is it supported OOTB? Test it.
        var userId = Guid.NewGuid();

        var user = ApplicationUser.Create(
            registerUserDTO.Email,
            registerUserDTO.FirstName,
            registerUserDTO.PhoneNumber,
            "secStamp", // TODO: What to do with this? This is probably not secure. Seems to get overwritten?
            userId,
            userId,
            registerUserDTO.MiddleName,
            registerUserDTO.LastName
            );

        var result = await _userManager.CreateAsync(user, registerUserDTO.Password);

        // TODO: Invert if. Clean up.
        if (result.Succeeded)
        {
            var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var success = await _emailService.SendEmailConfirmationRequest(
                new EmailConfirmationRequest()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName,
                    ConfirmationToken = confirmationToken
                });

            if (!success)
            {
                // TODO: Figure out what to do in this case exactly. Maybe delete the user?
                throw new BadRequestException("Failed to send email confirmation. User created successfully though.");
            }

            return user.Id;
        }
        else
        {
            // TODO: Maybe it is not the best idea to expose the error messages to the client. Or perhaps they are save?
            throw new BadRequestException($"Failed to register user: {string.Join(", ", result.Errors.ToList().Select(e => e.Description))}");
        }
    }

    public async Task<Guid> LoginUser(LoginUserDTO loginUserDTO)
    {
        var result = await _signInManager.PasswordSignInAsync(loginUserDTO.Email, loginUserDTO.Password, loginUserDTO.RememberMe, false);

        // TODO: Clean up this if-else logic. It is a bit messy. Invert ifs if possible.
        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(loginUserDTO.Email)
                ?? throw new NotFoundException($"User with email ({loginUserDTO.Email}) was not found");
            return user.Id;
        }
        else
        {
            if (result.IsNotAllowed)
            {
                // If it is not allowed, it is because they have their email not confirmed, for example. Make this exception more specific when you know exactly how you want to do it.
                throw new UnauthorizedException("User is not allowed to login");
            }
            else if (result.IsLockedOut)
            {
                throw new UnauthorizedException("User is locked out");
            }

            throw new UnauthorizedException("Failed to login user");
        }
    }

    public async Task<Guid> LogoutUser()
    {
        var userId = GetLoggedInUserId();

        await _signInManager.SignOutAsync();

        return userId;
    }

    public async Task<bool> ConfirmUserEmail(string email, string confirmEmailToken)
    {
        var user = await _userManager.FindByEmailAsync(email)
            ?? throw new NotFoundException($"User with email ({email}) was not found");

        var result = await _userManager.ConfirmEmailAsync(user, confirmEmailToken);

        // TODO: Clean up this if-else logic. It is a bit messy. Invert ifs if possible.
        if (result.Succeeded)
        {
            if (!user.EmailConfirmed)
            {
                var success = await _emailService.SendEmailConfirmationAcceptance(
                    new EmailConfirmationAcceptance()
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        MiddleName = user.MiddleName,
                        LastName = user.LastName
                    });
                return success;
            }
            return true;
        }

        throw new BadRequestException("Failed to confirm email");
    }

    public async Task<Guid> RequestUserPasswordReset(string email)
    {
        var user = await _userManager.FindByEmailAsync(email)
             ?? throw new NotFoundException($"User with email ({email}) was not found");

        if (!user.EmailConfirmed)
        {
            throw new UnauthorizedException("User email is not confirmed. Cannot reset password for unconfirmed email.");
        }

        if (user.LockoutEnabled)
        {
            throw new UnauthorizedException("User is locked out. Cannot reset password for locked out user.");
        }

        var passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

        var success = await _emailService.SendResetPasswordRequest(
            new ResetPasswordRequest()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                ResetPasswordToken = passwordResetToken
            });

        if (!success)
        {
            throw new BadRequestException("Failed to send password reset email");
        }

        return user.Id;
    }

    public async Task<bool> ConfirmUserPasswordReset(string email, string newPassword, string newPasswordConfirmation, string resetPasswordToken)
    {
        if (newPassword != newPasswordConfirmation)
        {
            throw new BadRequestException("The inputted passwords do not match");
        }

        var user = await _userManager.FindByEmailAsync(email)
            ?? throw new NotFoundException($"User with email ({email}) was not found");

        var result = await _userManager.ResetPasswordAsync(user, resetPasswordToken, newPassword);

        // TODO: Invert if.
        if (result.Succeeded)
        {
            // TODO: Currently, this functionality can be spammed. How do we prevent this?
            var success = await _emailService.SendResetPasswordAcceptance(
                new ResetPasswordAcceptance()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName
                });
            return success;
        }

        return false;
    }
}