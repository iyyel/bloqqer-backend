namespace Bloqqer.Infrastructure.Models.Interfaces;

public interface IBaseEntity<TKey> where TKey : IEquatable<TKey>
{
    TKey? CreatedBy { get; set; }

    DateTime? CreatedOn { get; set; }

    TKey? ModifiedBy { get; set; }

    DateTime? ModifiedOn { get; set; }

    TKey? DeletedBy { get; set; }

    DateTime? DeletedOn { get; set; }
}