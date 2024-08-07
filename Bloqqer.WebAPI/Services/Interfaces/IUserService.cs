using Bloqqer.Domain.Models;
using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services.Interfaces;

public interface IUserService
{
    Guid GetLoggedInUserId();

    Task<ApplicationUser> GetLoggedInUser();

    Task<ApplicationUser> GetUserByUserId(Guid userId);

    Task<ICollection<UserDTO>> GetAllUsers();
}