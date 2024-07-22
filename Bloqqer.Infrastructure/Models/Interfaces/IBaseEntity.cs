namespace Bloqqer.Infrastructure.Models.Interfaces;

public interface IBaseEntity
{
    string? CreatedBy { get; set; }

    DateTime? CreatedOn { get; set; }

    string? ModifiedBy { get; set; }

    DateTime? ModifiedOn { get; set; }

    string? DeletedBy { get; set; }

    DateTime? DeletedOn { get; set; }
}