namespace FlashCards.DataAccess.Entities;

public sealed class FlashCardSet : BaseEntity<Guid>
{
    public const int MaxTitleLength = 256;

    // TODO: Required?
    public Guid? ApplicationUserId { get; set; }

    // TODO: Required?
    public ApplicationUser? ApplicationUser { get; set; }

    public required string Title { get; set; }

    public required ICollection<FlashCard> FlashCards { get; set; }
}