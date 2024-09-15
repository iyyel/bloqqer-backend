namespace Bloqqer.Domain.Models;

public class Reaction : GUIDEntity
{
    public required Guid AuthorId { get; set; }

    public virtual ApplicationUser? Author { get; set; }

    public Guid? BloqId { get; set; }

    public virtual Bloq? Bloq { get; set; }

    public Guid? PostId { get; set; }

    public virtual Post? Post { get; set; }

    public Guid? CommentId { get; set; }

    public virtual Comment? Comment { get; set; }
}