using Bloqqer.DataAccess.Models;

namespace Bloqqer.DataAccess.Repositories.Interfaces;

public interface IApplicationUserRepository : IRepository<Guid, ApplicationUser>
{
    ApplicationUser FindUserByUsername(string username);
}