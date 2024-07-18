using FlashCards.DataAccess.Repositories.Interfaces;

namespace FlashCards.DataAccess.Repositories.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IFlashCardRepository FlashCards { get; }
    IFlashCardSetRepository FlashCardSets { get; }
    IApplicationUserRepository ApplicationUsers { get; }

    bool Save();
    Task<bool> SaveAsync();
}