using Bloqqer.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bloqqer.Infrastructure.Repositories;

public class Repository<TEntity>(DbContext dbContext)
    : IGuidRepository<TEntity> where TEntity : class
{
    protected readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual async Task AddRangeAsync(ICollection<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public virtual async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.SingleOrDefaultAsync(predicate);
    }

    public virtual void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void UpdateRange(ICollection<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public virtual void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public virtual void DeleteRange(ICollection<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}