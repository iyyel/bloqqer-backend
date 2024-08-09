namespace Bloqqer.Infrastructure.ViewModels;

public class ViewFollowsDTO
{
    public required Guid UserId { get; set; }

    public required ICollection<ViewUserDTO> Follows { get; set; }
}