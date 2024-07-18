namespace FlashCards.DataAccess.Models;

public sealed class FlashCardSet
{
    public Guid Id { get; set; }

    public required string SetName { get; set; }

    public required ICollection<FlashCard> FlashCards { get; set; }
}