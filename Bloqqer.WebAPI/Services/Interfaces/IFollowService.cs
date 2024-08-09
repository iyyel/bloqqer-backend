using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services.Interfaces;

public interface IFollowService
{
    Task<Guid> FollowUser(Guid followedId);

    Task<Guid> UnfollowUser(Guid followedId);

    Task<ViewFollowsDTO> GetFollowers(Guid userId);

    Task<ViewFollowsDTO> GetFollowing(Guid userId);
}