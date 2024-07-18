using FlashCards.DataAccess.Contexts;
using FlashCards.DataAccess.Models;
using FlashCards.DataAccess.Repositories.Interfaces;

namespace FlashCards.DataAccess.Repositories;

public sealed class ApplicationUserRepository(ApplicationDbContext context)
    : Repository<Guid, ApplicationUser>(context), IApplicationUserRepository
{
    public ApplicationUser FindUserByUsername(string username)
    {
        return _dbContext.Users.SingleOrDefault(user => user.UserName == username);
    }

    private ApplicationDbContext _dbContext
    {
        get { return _dbContext as ApplicationDbContext; }
    }
}