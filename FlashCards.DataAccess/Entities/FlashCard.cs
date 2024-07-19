namespace FlashCards.DataAccess.Entities;

public sealed class FlashCard : BaseEntity<Guid>
{
    public const int MaxFrontTextLength = 256;

    public const int MaxBackTextLength = 256;

    public required Guid? FlashCardSetId { get; set; }

    public required FlashCardSet FlashCardSet { get; set; }

    public required string FrontText { get; set; }

    public required string BackText { get; set; }
}