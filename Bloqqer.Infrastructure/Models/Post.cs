namespace Bloqqer.Infrastructure.Models;

public class Post : BaseEntity<Guid>
{
    public const int MaxTitleLength = 256;

    public const int MaxDescriptionLength = 256;

    public const int MaxContentLength = 256;

    public Guid? BloqId { get; set; }

    public Bloq? Bloq { get; set; }

    public required Guid ApplicationUserId { get; set; }

    public virtual ApplicationUser? ApplicationUser { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required string Content { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }

    public required virtual ICollection<Comment> Comments { get; set; }
}