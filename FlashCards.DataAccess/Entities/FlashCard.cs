namespace FlashCards.DataAccess.Entities;

public sealed class FlashCard : BaseEntity<Guid>
{
    public const int MaxFrontTextLength = 256;

    public const int MaxBackTextLength = 256;

    // TODO: Required?
    public Guid? FlashCardSetId { get; set; }

    // TODO: Required?
    public FlashCardSet? FlashCardSet { get; set; }

    public required string FrontText { get; set; }

    public required string BackText { get; set; }
}