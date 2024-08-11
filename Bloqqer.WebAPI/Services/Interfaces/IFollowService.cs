using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services.Interfaces;

public interface IFollowService
{
    Task<Guid> FollowUser(Guid userId);

    Task<Guid> UnfollowUser(Guid userId);

    Task<ViewFollowsDTO> GetFollowers(Guid userId);

    Task<ViewFollowsDTO> GetFollowing(Guid userId);
}