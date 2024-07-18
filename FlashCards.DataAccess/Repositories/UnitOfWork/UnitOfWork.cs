using FlashCards.DataAccess.Contexts;
using FlashCards.DataAccess.Repositories.Interfaces;

namespace FlashCards.DataAccess.Repositories.UnitOfWork;

public sealed class UnitOfWork(
    ApplicationDbContext dbContext,
    IFlashCardRepository flashCards,
    IFlashCardSetRepository flashCardSets,
    IApplicationUserRepository applicationUsers
) : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public IFlashCardRepository FlashCards { get; } = flashCards;

    public IFlashCardSetRepository FlashCardSets { get; } = flashCardSets;

    public IApplicationUserRepository ApplicationUsers { get; } = applicationUsers;

    public bool Save() =>
        _dbContext.SaveChanges() >= 0;

    public async Task<bool> SaveAsync() =>
        await _dbContext.SaveChangesAsync() >= 0;

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