using Bloqqer.Domain.Models.Interfaces;

namespace Bloqqer.Domain.Models;

public abstract class BaseEntity<TKey>
    : IBaseEntity<TKey> where TKey : IEquatable<TKey>
{
    public required TKey Id { get; set; }

    public TKey? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public TKey? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public TKey? RemovedBy { get; set; }

    public DateTime? RemovedOn { get; set; }
}