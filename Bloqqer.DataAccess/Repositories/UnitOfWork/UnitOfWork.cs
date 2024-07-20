using Bloqqer.DataAccess.Contexts;
using Bloqqer.DataAccess.Repositories.Interfaces;

namespace Bloqqer.DataAccess.Repositories.UnitOfWork;

public sealed class UnitOfWork(
    ApplicationDbContext dbContext,
    IApplicationUserRepository applicationUsers,
    IBloqRepository bloqs,
    IPostRepository posts,
    ICommentRepository comments
) : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public IApplicationUserRepository ApplicationUsers { get; } = applicationUsers;

    public IBloqRepository Bloqs { get; } = bloqs;

    public IPostRepository Posts { get; } = posts;

    public ICommentRepository Comments { get; } = comments;

    public bool Save()
    {
        return _dbContext.SaveChanges() >= 0;
    }

    public async Task<bool> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync() >= 0;
    }

    public void Dispose()
    {
        try
        {
            _dbContext.Dispose();
        }
        catch (Exception e)
        {
            // _logger.LogError("Dispose UnitOfWork", e, "faild to dispose unit of work");
            throw;
        }
    }
}