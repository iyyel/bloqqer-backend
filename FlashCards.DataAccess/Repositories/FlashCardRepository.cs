using FlashCards.DataAccess.Contexts;
using FlashCards.DataAccess.Models;

namespace FlashCards.DataAccess.Repositories;

public class FlashCardRepository : Repository<FlashCard, Guid>
{

    public FlashCardRepository(AppDbContext context) : base(context)
    {

    }
}