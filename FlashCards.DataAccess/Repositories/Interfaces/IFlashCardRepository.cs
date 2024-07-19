using FlashCards.DataAccess.Entities;

namespace FlashCards.DataAccess.Repositories.Interfaces;

public interface IFlashCardRepository : IRepository<Guid, FlashCard>
{

}