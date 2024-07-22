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

    public DateTime? Published { get; set; }

    public required bool IsPrivate { get; set; }

    public required ICollection<Post> Posts { get; set; }

    public static Bloq Create(
        Guid? applicationUserId,
        ApplicationUser? applicationUser,
        string title,
        string description,
        bool isPrivate,
        string createdBy,
        ICollection<Post>? posts = null,
        DateTime? published = null,
        bool isPublished = false)
    {
        return new Bloq()
        {
            Id = Guid.NewGuid(),
            ApplicationUserId = applicationUserId,
            ApplicationUser = applicationUser,
            Title = title,
            Description = description,
            IsPrivate = isPrivate,
            Posts = posts ?? [],
            Published = published ?? null,
            IsPublished = isPublished,
            CreatedBy = createdBy,
            CreatedOn = DateTime.UtcNow
        };
    }
}