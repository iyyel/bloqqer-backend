namespace Bloqqer.Infrastructure.ViewModels;

public sealed class BloqMetadataDTO
{
    public required Guid Id { get; set; }

    public required Guid AuthorId { get; set; }

    public required string AuthorFirstName { get; set; }

    public required string AuthorMiddleName { get; set; }

    public required string AuthorLastName { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required bool IsPrivate { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }

    public required int PostCount { get; set; }

    public required int ReactionCount { get; set; }
}
