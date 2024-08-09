using Bloqqer.Application.Exceptions;
using Bloqqer.Domain.Models;
using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Services.Interfaces;

namespace Bloqqer.WebAPI.Services;

public sealed class FollowService(
    IUnitOfWork _unitOfWork,
    IUserService userService
) : IFollowService
{
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    private readonly IUserService _userService = userService;

    public async Task<Guid> FollowUser(Guid followedId)
    {
        var followerId = _userService.GetLoggedInUserId();

        if (followerId == followedId)
        {
            throw new BadRequestException("You cannot follow yourself");
        }

        _ = await _unitOfWork.ApplicationUsers.GetByIdAsync(followedId)
           ?? throw new NotFoundException($"User with Id ({followedId}) was not found");

        await _unitOfWork.Follows.AddAsync(
            Follow.Create(
                followerId,
                followedId,
                followerId
        ));
        await _unitOfWork.SaveChangesAsync();

        return followedId;
    }

    public async Task<Guid> UnfollowUser(Guid followedId)
    {
        var followerId = _userService.GetLoggedInUserId();

        _ = await _unitOfWork.Follows.FindAsync(f => f.FollowedId == followedId && f.FollowerId == followerId)
            ?? throw new NotFoundException($"User with Id ({followerId}) does not follow User with Id ({followedId})");

        return followedId;
    }

    public async Task<ViewFollowsDTO> GetFollowers(Guid userId)
    {
        var follows = await _unitOfWork.Follows.FindAsync(f => f.FollowedId == userId);

        var followedIds = follows.Select(f => f.FollowerId).ToList();

        var followedUsers = await _unitOfWork.ApplicationUsers.FindAsync(u => followedIds.Contains(u.Id));

        return new ViewFollowsDTO()
        {
            UserId = userId,
            Follows = followedUsers.Select(u =>
                new ViewUserDTO()
                {
                    FirstName = u.FirstName,
                    MiddleName = u.MiddleName,
                    LastName = u.LastName,
                }).ToList()
        };
    }

    public async Task<ViewFollowsDTO> GetFollowing(Guid userId)
    {
        var follows = await _unitOfWork.Follows.FindAsync(f => f.FollowerId == userId);

        var followerIds = follows.Select(f => f.FollowedId).ToList();

        var followers = await _unitOfWork.ApplicationUsers.FindAsync(u => followerIds.Contains(u.Id));

        return new ViewFollowsDTO()
        {
            UserId = userId,
            Follows = followers.Select(u =>
                new ViewUserDTO()
                {
                    FirstName = u.FirstName,
                    MiddleName = u.MiddleName,
                    LastName = u.LastName,
                }).ToList()
        };
    }
}