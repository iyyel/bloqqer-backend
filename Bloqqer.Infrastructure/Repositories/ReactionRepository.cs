using Bloqqer.Domain.Models;
using Bloqqer.Infrastructure.Database;
using Bloqqer.Infrastructure.Repositories.Interfaces;

namespace Bloqqer.Infrastructure.Repositories;

public sealed class ReactionRepository(ApplicationDbContext dbContext)
    : Repository<Reaction>(dbContext), IReactionRepository
{

}