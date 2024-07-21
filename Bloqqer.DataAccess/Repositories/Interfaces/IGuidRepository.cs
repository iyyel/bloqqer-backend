namespace Bloqqer.DataAccess.Repositories.Interfaces;

public interface IGuidRepository<TEntity>
    : IRepository<Guid, TEntity> where TEntity : class
{

}