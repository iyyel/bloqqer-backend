using Bloqqer.Infrastructure.Repositories.Interfaces;

namespace Bloqqer.Infrastructure.UnitOfWork.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IApplicationUserRepository ApplicationUsers { get; }

    IBloqRepository Bloqs { get; }

    IPostRepository Posts { get; }

    ICommentRepository Comments { get; }

    bool SaveChanges();

    Task<bool> SaveChangesAsync();
}