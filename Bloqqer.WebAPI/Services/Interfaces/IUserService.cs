using Bloqqer.Domain.Models;
using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services.Interfaces;

public interface IUserService
{
    Guid GetLoggedInUserId();

    // TODO: Make a view model here.
    Task<ApplicationUser> GetLoggedInUser();

    // TODO: Make a view model here.
    Task<ApplicationUser> GetUserByUserId(Guid userId);

    Task<Guid> RegisterUser(RegisterUserDTO registerUserDTO);

    Task<Guid> LoginUser(LoginUserDTO loginUserDTO);

    Task<Guid> LogoutUser();

    Task<bool> ConfirmUserEmail(string email, string confirmEmailToken);

    Task<Guid> RequestUserPasswordReset(string email);

    Task<bool> ConfirmUserPasswordReset(string email, string newPassword, string newPasswordConfirmation, string resetPasswordToken);
}