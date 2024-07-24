using Bloqqer.Infrastructure.Database;
using Bloqqer.Infrastructure.Models;
using Bloqqer.Infrastructure.Repositories.Interfaces;

namespace Bloqqer.Infrastructure.Repositories;

public sealed class ReactionRepository(ApplicationDbContext dbContext)
    : Repository<Reaction>(dbContext), IReactionRepository
{

}