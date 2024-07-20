using Bloqqer.DataAccess.Contexts;
using Bloqqer.DataAccess.Models;
using Bloqqer.DataAccess.Repositories.Interfaces;

namespace Bloqqer.DataAccess.Repositories;

public sealed class ApplicationUserRepository(ApplicationDbContext context)
    : Repository<Guid, ApplicationUser>(context), IApplicationUserRepository
{
    public ApplicationUser FindUserByUsername(string username)
    {
        return _dbContext.Users.SingleOrDefault(i => i.UserName == username);
    }

    private new ApplicationDbContext _dbContext
    {
        get { return _dbContext; }
    }
}