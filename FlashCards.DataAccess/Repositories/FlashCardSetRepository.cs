using FlashCards.DataAccess.Contexts;
using FlashCards.DataAccess.Models;
using FlashCards.DataAccess.Repositories.Interfaces;

namespace FlashCards.DataAccess.Repositories;

public sealed class FlashCardSetRepository(ApplicationDbContext context)
    : Repository<Guid, FlashCardSet>(context), IFlashCardSetRepository
{

}