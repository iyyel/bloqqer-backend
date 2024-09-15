using Microsoft.AspNetCore.Identity;

namespace Bloqqer.Domain.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public required string FirstName { get; set; }

    public required string MiddleName { get; set; }

    public required string LastName { get; set; }

    public virtual ICollection<Bloq>? AuthoredBloqs { get; set; }

    public virtual ICollection<Post>? AuthoredPosts { get; set; }

    public virtual ICollection<Comment>? AuthoredComments { get; set; }

    public virtual ICollection<Reaction>? AuthoredReactions { get; set; }

    public virtual ICollection<Follow>? Followers { get; set; }

    public virtual ICollection<Follow>? Following { get; set; }

    public required Guid CreatedBy { get; set; }

    public required DateTime CreatedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? RemovedBy { get; set; }

    public DateTime? RemovedOn { get; set; }
}