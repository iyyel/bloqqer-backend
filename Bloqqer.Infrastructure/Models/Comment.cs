namespace Bloqqer.Infrastructure.Models;

public class Comment : BaseEntity<Guid>
{
    public const int MaxContentLength = 256;

    public Guid? PostId { get; set; }

    public virtual Post? Post { get; set; }

    public required Guid ApplicationUserId { get; set; }

    public virtual ApplicationUser? ApplicationUser { get; set; }

    public required string Content { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }
}