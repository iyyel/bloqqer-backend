using Bloqqer.Infrastructure.Database;
using Bloqqer.Infrastructure.Repositories.Interfaces;
using Bloqqer.Infrastructure.UnitOfWork.Interfaces;

namespace Bloqqer.Infrastructure.UnitOfWork;

public sealed class UnitOfWork(
    ApplicationDbContext dbContext,
    IApplicationUserRepository applicationUsers,
    IBloqRepository bloqs,
    IPostRepository posts,
    ICommentRepository comments,
    IReactionRepository reactions,
    IFollowRepository follows
) : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public IApplicationUserRepository ApplicationUsers { get; } = applicationUsers;

    public IBloqRepository Bloqs { get; } = bloqs;

    public IPostRepository Posts { get; } = posts;

    public ICommentRepository Comments { get; } = comments;

    public IReactionRepository Reactions { get; } = reactions;

    public IFollowRepository Follows { get; } = follows;

    public bool SaveChanges()
    {
        return _dbContext.SaveChanges() >= 0;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync() >= 0;
    }

    public void Dispose()
    {
        try
        {
            _dbContext.Dispose();
        }
        catch (Exception)
        {
            // TODO: Actually use a logger.
            // _logger.LogError("Dispose UnitOfWork", e, "faild to dispose unit of work");
            throw;
        }
    }
}