namespace Bloqqer.Domain.Models;

public class Bloq : GUIDEntity
{
    public required Guid AuthorId { get; set; }

    public virtual ApplicationUser? Author { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required bool IsPrivate { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }

    public virtual ICollection<Post>? Posts { get; set; }

    public virtual ICollection<Reaction>? Reactions { get; set; }
}