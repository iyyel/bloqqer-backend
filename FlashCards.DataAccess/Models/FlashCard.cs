namespace FlashCards.DataAccess.Models;

public sealed class FlashCard
{
    public Guid Id { get; set; }

    public required string Front { get; set; }

    public required string Back { get; set; }
}