namespace Bloqqer.DataAccess.Models;

public sealed class Bloq : BaseEntity<Guid>
{
    public const int MaxTitleLength = 256;

    public const int MaxDescriptionLength = 256;

    // TODO: Make required?
    public Guid? ApplicationUserId { get; set; }

    // TODO: Make required?
    public ApplicationUser? ApplicationUser { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required bool IsPublished { get; set; }

    public required DateTime? Published { get; set; }

    public required bool IsPrivate { get; set; }

    public required ICollection<Post> Posts { get; set; }
}