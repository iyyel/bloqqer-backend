namespace FlashCards.DataAccess.Models;

public sealed class FlashCardGroup
{
    public Guid Id { get; set; }

    public required ICollection<FlashCard> FlashCards { get; set; }
}