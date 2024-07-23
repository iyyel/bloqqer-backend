namespace Bloqqer.Infrastructure.Models;

public class Reaction : BaseEntity<Guid>
{
    public Guid? BloqId { get; set; }

    public virtual Bloq? Bloq { get; set; }

    public Guid? PostId { get; set; }

    public virtual Post? Post { get; set; }

    public Guid? CommentId { get; set; }

    public virtual Comment? Comment { get; set; }

    public Guid? ReactorId { get; set; }

    public virtual ApplicationUser? Reactor { get; set; }
}