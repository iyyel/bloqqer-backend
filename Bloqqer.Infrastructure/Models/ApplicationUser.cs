using Bloqqer.Infrastructure.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Bloqqer.Infrastructure.Models;

public class ApplicationUser : IdentityUser<Guid>, IBaseEntity<Guid>
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

    public virtual ICollection<Reaction>? Reactions { get; set; }

    public virtual ICollection<Follow>? Followers { get; set; }

    public virtual ICollection<Follow>? Following { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    // TODO: Is there a better way to have a 'Create' method? This is not very readable when invoked.
    // Object initializion syntax is more readable.
    public static ApplicationUser Create(
        string email,
        string firstName,
        string phoneNumber,
        string securityStamp,
        Guid createdBy,
        Guid? id = null,
        string? middleName = "",
        string? lastName = "",
        bool? lockoutEnabled = false,
        bool? emailConfirmed = true,
        bool? phoneNumberConfirmed = true,
        bool? twoFactorEnabled = false)
    {
        return new ApplicationUser()
        {
            Id = id ?? Guid.NewGuid(),
            UserName = email,
            NormalizedUserName = email.ToUpper(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            SecurityStamp = securityStamp,
            CreatedBy = createdBy,
            LockoutEnabled = lockoutEnabled ?? false,
            EmailConfirmed = emailConfirmed ?? true,
            PhoneNumberConfirmed = phoneNumberConfirmed ?? true,
            TwoFactorEnabled = twoFactorEnabled ?? false,
            CreatedOn = DateTime.UtcNow,
            Bloqs = [],
            Posts = [],
            Comments = [],
            Reactions = [],
            Followers = [],
            Following = [],
        };
    }
}