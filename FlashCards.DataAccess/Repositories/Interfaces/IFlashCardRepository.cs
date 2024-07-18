using FlashCards.DataAccess.Models;

namespace FlashCards.DataAccess.Repositories.Interfaces;

public interface IFlashCardRepository : IRepository<Guid, FlashCard>
{

}