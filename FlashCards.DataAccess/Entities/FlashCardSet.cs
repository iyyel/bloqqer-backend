namespace FlashCards.DataAccess.Entities;

public sealed class FlashCardSet : BaseEntity<Guid>
{
    public const int MaxTitleLength = 256;

    public required Guid ApplicationUserId { get; set; }

    public required ApplicationUser ApplicationUser { get; set; }

    public required string Title { get; set; }

    public required ICollection<FlashCard> FlashCards { get; set; }
}