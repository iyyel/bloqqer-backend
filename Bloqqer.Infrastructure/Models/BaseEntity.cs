using Bloqqer.Infrastructure.Models.Interfaces;

namespace Bloqqer.Infrastructure.Models;

public abstract class BaseEntity<TKey>
    : IBaseEntity where TKey : IEquatable<TKey>
{
    public required TKey Id { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }
}