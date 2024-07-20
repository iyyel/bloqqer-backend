using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.DataAccess.Services.Interfaces;

public interface IUserService
{
    Task<ICollection<UserDTO>> GetAllUsers();
}