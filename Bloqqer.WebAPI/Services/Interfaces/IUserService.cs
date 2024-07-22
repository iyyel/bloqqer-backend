using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services.Interfaces;

public interface IUserService
{
    Task<ICollection<UserDTO>> GetAllUsers();

    Guid? GetLoggedInUserId();
}