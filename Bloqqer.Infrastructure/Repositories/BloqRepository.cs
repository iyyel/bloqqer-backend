using Bloqqer.Domain.Models;
using Bloqqer.Infrastructure.Database;
using Bloqqer.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bloqqer.Infrastructure.Repositories;

public sealed class BloqRepository(ApplicationDbContext dbContext)
    : Repository<Bloq>(dbContext), IBloqRepository
{
    public override async Task<Bloq?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(b => b.Posts)
            .Include(b => b.Reactions)
            .SingleOrDefaultAsync(b => b.Id == id);
    }

    public override async Task<ICollection<Bloq>> GetAllAsync()
    {
        return await _dbSet
            .Include(b => b.Posts)
            .Include(b => b.Reactions)
            .ToListAsync();
    }

    public override async Task<ICollection<Bloq>> FindAsync(Expression<Func<Bloq, bool>> predicate)
    {
        return await _dbSet
            .Include(b => b.Posts)
            .Include(b => b.Reactions)
            .Where(predicate)
            .ToListAsync();
    }

    public override async Task<Bloq?> SingleOrDefaultAsync(Expression<Func<Bloq, bool>> predicate)
    {
        return await _dbSet
            .Include(b => b.Posts)
            .Include(b => b.Reactions)
            .SingleOrDefaultAsync(predicate);
    }
}