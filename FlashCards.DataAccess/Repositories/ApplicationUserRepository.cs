using FlashCards.DataAccess.Contexts;
using FlashCards.DataAccess.Entities;
using FlashCards.DataAccess.Repositories.Interfaces;

namespace FlashCards.DataAccess.Repositories;

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