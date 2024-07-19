namespace FlashCards.DataAccess.Entities;

public class FlashCard : BaseEntity<Guid>
{
    public required string Front { get; set; }

    public required string Back { get; set; }
}