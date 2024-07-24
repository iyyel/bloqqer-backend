using System.Text.Json.Serialization;

namespace Bloqqer.Infrastructure.Models;

public class Follow : BaseEntity<Guid>
{
    public Guid? FollowedId { get; set; }

    // TODO: Find a better solution for this JSON ignore. Use dedicated DTOs?
    [JsonIgnore]
    public virtual ApplicationUser? Followed { get; set; }

    public required Guid FollowerId { get; set; }

    // TODO: Find a better solution for this JSON ignore. Use dedicated DTOs?
    [JsonIgnore]
    public virtual ApplicationUser? Follower { get; set; }
}