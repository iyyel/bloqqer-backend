using FlashCards.DataAccess.Contexts;
using FlashCards.DataAccess.Models;
using FlashCards.DataAccess.Repositories.Interfaces;

namespace FlashCards.DataAccess.Repositories;

public sealed class FlashCardRepository(ApplicationDbContext context) : Repository<Guid, FlashCard>(context), IFlashCardRepository
{

}