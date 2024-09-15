using Bloqqer.Domain.Models;
using Bloqqer.Infrastructure.Database;
using Bloqqer.Infrastructure.Repositories.Interfaces;

namespace Bloqqer.Infrastructure.Repositories;

public sealed class ApplicationUserRepository(ApplicationDbContext dbContext)
    : Repository<ApplicationUser>(dbContext), IApplicationUserRepository
{
    public ApplicationUser? FindUserByUserName(string userName)
    {
        return _dbSet.SingleOrDefault(a => a.UserName == userName);
    }
}