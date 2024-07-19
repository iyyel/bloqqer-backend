using FlashCards.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FlashCards.DataAccess.Repositories;

public class Repository<TKey, TEntity>(DbContext context)
    : IRepository<TKey, TEntity> where TEntity : class
{
    protected readonly DbContext _dbContext = context;

    public async Task Add(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
    }

    public async Task AddRange(ICollection<TEntity> entities)
    {
        await _dbContext.Set<TEntity>().AddRangeAsync(entities);
    }

    public async Task<TEntity> Get(TKey id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<ICollection<TEntity>> GetAll()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<ICollection<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
    }

    public void Remove(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(ICollection<TEntity> entities)
    {
        _dbContext.Set<TEntity>().RemoveRange(entities);
    }
}