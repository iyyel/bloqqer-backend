using FlashCards.DataAccess.Models;

namespace FlashCards.DataAccess.Repositories.Interfaces;

public interface IApplicationUserRepository : IRepository<Guid, ApplicationUser>
{
    ApplicationUser FindUserByUsername(string username);
}