using FlashCards.DataAccess.Contexts;
using FlashCards.DataAccess.Models;
using FlashCards.DataAccess.Repositories.Interfaces;

namespace FlashCards.DataAccess.Repositories;

public sealed class ApplicationUserRepository(ApplicationDbContext context) : Repository<Guid, ApplicationUser>(context), IApplicationUserRepository
{
    public async Task<ApplicationUser> FindUserByUsername(string username)
    {
        // return await _dbContext.Users.SingleOrDefault(i => i.UserName == username);
        throw new NotImplementedException();
    }
}