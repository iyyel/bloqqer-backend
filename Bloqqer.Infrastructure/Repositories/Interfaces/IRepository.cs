using System.Linq.Expressions;

namespace Bloqqer.Infrastructure.Repositories.Interfaces;

public interface IRepository<TKey, TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);

    Task AddRangeAsync(ICollection<TEntity> entities);

    Task<TEntity?> GetByIdAsync(TKey id);

    Task<ICollection<TEntity>> GetAllAsync();

    Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

    void Update(TEntity entity);

    void UpdateRange(ICollection<TEntity> entities);

    void Delete(TEntity entity);

    void DeleteRange(ICollection<TEntity> entities);
}