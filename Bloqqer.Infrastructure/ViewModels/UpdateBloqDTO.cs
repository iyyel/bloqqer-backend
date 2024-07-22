namespace Bloqqer.Infrastructure.ViewModels;

public class UpdateBloqDTO
{
    public required Guid BloqId { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required bool IsPrivate { get; set; }

    public required bool IsPublished { get; set; }
}