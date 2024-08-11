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

    Task<string> RegisterUser(RegisterUserDTO registerUserDTO);

    Task<Guid> LoginUser(LoginUserDTO loginUserDTO);

    Task<bool> ConfirmUserEmail(string email, string confirmEmailToken);

    Task<string> RequestUserPasswordReset(string email);

    Task<bool> ConfirmUserPasswordReset(string email, string resetPasswordToken, string newPassword, string newPasswordConfirm);
}