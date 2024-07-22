using Bloqqer.Infrastructure.Database;
using Bloqqer.Infrastructure.Models;
using Bloqqer.Infrastructure.Repositories.Interfaces;

namespace Bloqqer.Infrastructure.Repositories;

public sealed class ApplicationUserRepository(ApplicationDbContext dbContext)
    : Repository<ApplicationUser>(dbContext), IApplicationUserRepository
{
    public ApplicationUser? FindUserByUserName(string username)
    {
        return _dbSet.SingleOrDefault(a => a.UserName == username);
    }
}