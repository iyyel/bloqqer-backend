namespace Bloqqer.Infrastructure.ViewModels;

public sealed record ViewFollowsDTO(
    Guid UserId,
    ICollection<ViewUserDTO> Follows
);