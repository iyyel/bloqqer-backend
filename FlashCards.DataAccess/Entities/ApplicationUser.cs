using Microsoft.AspNetCore.Identity;

namespace FlashCards.DataAccess.Entities;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    public const int MaxFirstNameLength = 256;

    public const int MaxMiddleNameLength = 256;

    public const int MaxLastNameLength = 256;

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public ICollection<FlashCardSet>? FlashCardSets { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}