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
    UserManager<ApplicationUser> _userManager,
    SignInManager<ApplicationUser> _signInManager
) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor = _httpContextAccessor;
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

    public async Task<string> RegisterUser(RegisterUserDTO registerUserDTO)
    {
        // TODO: Check if the user with the same email/userName already exists?
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

        if (result.Succeeded)
        {
            var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            // TODO: Send email with the confirmation token to the user's email address.
            // IMPORTANT: For now, we will return this as a string here for the confirmation. Usually, we we would return the userId.
            // Like this: return userId;
            return confirmationToken;
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

    public async Task<bool> ConfirmUserEmail(string email, string confirmEmailToken)
    {
        var user = await _userManager.FindByEmailAsync(email)
            ?? throw new NotFoundException($"User with email ({email}) was not found");

        var result = await _userManager.ConfirmEmailAsync(user, confirmEmailToken);

        return result.Succeeded;
    }

    public async Task<string> RequestUserPasswordReset(string email)
    {
        var user = await _userManager.FindByEmailAsync(email)
             ?? throw new NotFoundException($"User with email ({email}) was not found");
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        // TODO: send email to user...

        return token;
    }

    public async Task<bool> ConfirmUserPasswordReset(string email, string resetPasswordToken, string newPassword, string newPasswordConfirm)
    {
        // TODO: Invert this if logic. It is easier to read.
        if (newPassword.Equals(newPasswordConfirm))
        {
            var user = await _userManager.FindByEmailAsync(email)
                ?? throw new NotFoundException($"User with email ({email}) was not found");
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordToken, newPassword);

            if (result.Succeeded)
            {
                // TODO: send email confirmation to user.
                return true;
            }
        }
        return false;
    }
}