using Bloqqer.DataAccess.Contexts;
using Bloqqer.DataAccess.Models;
using Bloqqer.DataAccess.Repositories.Interfaces;

namespace Bloqqer.DataAccess.Repositories;

public sealed class BloqRepository(ApplicationDbContext dbContext)
    : Repository<Guid, Bloq>(dbContext), IBloqRepository
{

}