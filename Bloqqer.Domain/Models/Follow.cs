namespace Bloqqer.Domain.Models;

public class Follow : GUIDEntity
{
    public required Guid FollowerId { get; set; }

    public virtual ApplicationUser? Follower { get; set; }

    public required Guid FollowedId { get; set; }

    public virtual ApplicationUser? Followed { get; set; }
}