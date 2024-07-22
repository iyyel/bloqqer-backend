using Bloqqer.Infrastructure.Database;
using Bloqqer.Infrastructure.Models;
using Bloqqer.Infrastructure.Repositories.Interfaces;

namespace Bloqqer.Infrastructure.Repositories;

public sealed class BloqRepository(ApplicationDbContext dbContext)
    : Repository<Bloq>(dbContext), IBloqRepository
{

}