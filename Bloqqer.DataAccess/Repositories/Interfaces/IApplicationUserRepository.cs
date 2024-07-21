using Bloqqer.DataAccess.Models;

namespace Bloqqer.DataAccess.Repositories.Interfaces;

public interface IApplicationUserRepository : IGuidRepository<ApplicationUser>
{
    ApplicationUser? FindUserByUserName(string userName);
}