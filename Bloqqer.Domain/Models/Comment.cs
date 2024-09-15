namespace Bloqqer.Domain.Models;

public class Comment : GUIDEntity
{
    public required Guid AuthorId { get; set; }

    public virtual ApplicationUser? Author { get; set; }

    public required Guid PostId { get; set; }

    public virtual Post? Post { get; set; }

    public required string Content { get; set; }

    public virtual ICollection<Reaction>? Reactions { get; set; }
}