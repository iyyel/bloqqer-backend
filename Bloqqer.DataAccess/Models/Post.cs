namespace Bloqqer.DataAccess.Models;

public sealed class Post : BaseEntity<Guid>
{
    public const int MaxTitleLength = 256;

    public const int MaxDescriptionLength = 256;

    public const int MaxContentLength = 256;

    public required Guid BloqId { get; set; }

    public required Bloq Bloq { get; set; }

    public required Guid ApplicationUserId { get; set; }

    public required ApplicationUser ApplicationUser { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required string Content { get; set; }

    public required bool IsPublished { get; set; }

    public required DateTime? Published { get; set; }

    public required ICollection<Comment> Comments { get; set; }
}