namespace Bloqqer.Domain.Models;

public class Post : GUIDEntity
{
    public required Guid AuthorId { get; set; }

    public virtual ApplicationUser? Author { get; set; }

    public required Guid BloqId { get; set; }

    public virtual Bloq? Bloq { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required string Content { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }

    public virtual ICollection<Reaction>? Reactions { get; set; }
}