using Bloqqer.DataAccess.Contexts;
using Bloqqer.DataAccess.Models;
using Bloqqer.DataAccess.Repositories.Interfaces;

namespace Bloqqer.DataAccess.Repositories;

public sealed class ApplicationUserRepository(ApplicationDbContext dbContext)
    : Repository<ApplicationUser>(dbContext), IApplicationUserRepository
{
    public ApplicationUser? FindUserByUserName(string username)
    {
        return _dbSet.SingleOrDefault(a => a.UserName == username);
    }
}