namespace FlashCards.DataAccess.Entities;

public abstract class BaseEntity<TId>
{
    public required TId Id { get; set; }

    public required string CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public required DateTime CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }
}