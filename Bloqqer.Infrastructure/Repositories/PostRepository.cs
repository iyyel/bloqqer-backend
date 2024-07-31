using Bloqqer.Infrastructure.Database;
using Bloqqer.Infrastructure.Models;
using Bloqqer.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bloqqer.Infrastructure.Repositories;

public sealed class PostRepository(ApplicationDbContext dbContext)
    : Repository<Post>(dbContext), IPostRepository
{
    public override async Task<Post?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(p => p.Comments)
            .Include(p => p.Reactions)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<ICollection<Post>> GetAllAsync()
    {
        return await _dbSet
            .Include(p => p.Comments)
            .Include(p => p.Reactions)
            .ToListAsync();
    }

    public override async Task<ICollection<Post>> FindAsync(Expression<Func<Post, bool>> predicate)
    {
        return await _dbSet
            .Include(p => p.Comments)
            .Include(p => p.Reactions)
            .Where(predicate)
            .ToListAsync();
    }

    public override async Task<Post?> SingleOrDefaultAsync(Expression<Func<Post, bool>> predicate)
    {
        return await _dbSet
            .Include(p => p.Comments)
            .Include(p => p.Reactions)
            .SingleOrDefaultAsync(predicate);
    }
}