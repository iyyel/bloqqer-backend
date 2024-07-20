using Bloqqer.DataAccess.Repositories.Interfaces;

namespace Bloqqer.DataAccess.Repositories.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IApplicationUserRepository ApplicationUsers { get; }

    IBloqRepository Bloqs { get; }

    IPostRepository Posts { get; }

    ICommentRepository Comments { get; }

    bool Save();

    Task<bool> SaveAsync();
}