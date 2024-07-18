using System.Linq.Expressions;

namespace FlashCards.DataAccess.Repositories.Interfaces;

public interface IRepository<TEntity, TId> where TEntity : class
{
    Task Add(TEntity entity);
    Task AddRange(ICollection<TEntity> entities);
    Task<TEntity> Get(TId id);
    Task<ICollection<TEntity>> GetAll();
    Task<ICollection<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    void Remove(TEntity entity);
    void RemoveRange(ICollection<TEntity> entities);
}