namespace Bloqqer.Domain.Models;

public abstract class BaseEntity<TKey> where TKey : struct
{
    public required TKey Id { get; set; }

    public required TKey CreatedBy { get; set; }

    public required DateTime CreatedOn { get; set; }

    public TKey? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public TKey? RemovedBy { get; set; }

    public DateTime? RemovedOn { get; set; }
}