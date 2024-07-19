using FlashCards.Infrastructure.ViewModels;

namespace FlashCards.DataAccess.Services.Interfaces;

public interface IUserService
{
    Task<ICollection<UserDTO>> GetAllUsers();
}