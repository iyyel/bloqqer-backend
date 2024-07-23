namespace Bloqqer.Infrastructure.Models;

public class Follow : BaseEntity<Guid>
{
    public Guid? FollowedId { get; set; }

    public virtual ApplicationUser? Followed { get; set; }

    public required Guid FollowerId { get; set; }

    public virtual ApplicationUser? Follower { get; set; }
}