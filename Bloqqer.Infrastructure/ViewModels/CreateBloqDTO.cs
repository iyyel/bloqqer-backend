namespace Bloqqer.Infrastructure.ViewModels;

public sealed class CreateBloqDTO
{
    public required string Title { get; set; }

    public required string Description { get; set; }

    public required bool IsPrivate { get; set; }
}