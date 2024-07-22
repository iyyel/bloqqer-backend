using Bloqqer.Infrastructure.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Bloqqer.Infrastructure.Models;

public class ApplicationUser : IdentityUser<Guid>, IBaseEntity
{
    public const int MaxFirstNameLength = 256;

    public const int MaxMiddleNameLength = 256;

    public const int MaxLastNameLength = 256;

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public virtual ICollection<Bloq>? Bloqs { get; set; }

    public virtual ICollection<Post>? Posts { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }
}