using Bloqqer.Domain.Models;

namespace Bloqqer.Infrastructure.Repositories.Interfaces;

public interface IApplicationUserRepository : IGuidRepository<ApplicationUser>
{
    ApplicationUser? FindUserByUserName(string userName);
}