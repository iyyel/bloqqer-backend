namespace Bloqqer.DataAccess.Models;

public sealed class Comment : BaseEntity<Guid>
{
    public const int MaxContentLength = 256;

    public Guid? PostId { get; set; }

    public required Post Post { get; set; }

    public required Guid ApplicationUserId { get; set; }

    public required ApplicationUser ApplicationUser { get; set; }

    public required string Content { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }
}