namespace FlashCards.DataAccess.Entities;

public class FlashCardSet : BaseEntity<Guid>
{
    public required virtual ApplicationUser User { get; set; }

    public required string SetName { get; set; }

    public required virtual ICollection<FlashCard> FlashCards { get; set; }
}