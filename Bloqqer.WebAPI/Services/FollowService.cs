using Bloqqer.Application.Exceptions;
using Bloqqer.Domain.Models;
using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Services.Interfaces;

namespace Bloqqer.WebAPI.Services;

public sealed class FollowService(
    IUnitOfWork _unitOfWork,
    IUserService _userService
) : IFollowService
{
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    private readonly IUserService _userService = _userService;

    public async Task<Guid> FollowUser(Guid userId)
    {
        var followerId = _userService.GetLoggedInUserId();

        if (followerId == userId)
        {
            throw new BadRequestException("You cannot follow yourself");
        }

        _ = await _unitOfWork.ApplicationUsers.GetByIdAsync(userId)
           ?? throw new NotFoundException($"User with Id ({userId}) was not found");

        await _unitOfWork.Follows.AddAsync(
              new Follow
              {
                  Id = Guid.NewGuid(),
                  FollowerId = followerId,
                  FollowedId = userId,
                  CreatedBy = followerId,
                  CreatedOn = DateTime.UtcNow
              }
        );
        await _unitOfWork.SaveChangesAsync();

        return userId;
    }

    public async Task<Guid> UnfollowUser(Guid userId)
    {
        var followerId = _userService.GetLoggedInUserId();

        _ = await _unitOfWork.Follows.FindAsync(f => f.FollowedId == userId && f.FollowerId == followerId)
            ?? throw new NotFoundException($"User with Id ({followerId}) does not follow User with Id ({userId})");

        return userId;
    }

    public async Task<ViewFollowsDTO> GetFollowers(Guid userId)
    {
        var follows = await _unitOfWork.Follows.FindAsync(f => f.FollowedId == userId);

        var followedIds = follows.Select(f => f.FollowerId).ToList();

        var followedUsers = await _unitOfWork.ApplicationUsers.FindAsync(u => followedIds.Contains(u.Id));

        return new ViewFollowsDTO(
            UserId: userId,
            Follows: followedUsers.Select(a =>
                new ViewUserDTO(
                    FirstName: a.FirstName,
                    MiddleName: a.MiddleName,
                    LastName: a.LastName
                )).ToList()
        );
    }

    public async Task<ViewFollowsDTO> GetFollowing(Guid userId)
    {
        var follows = await _unitOfWork.Follows.FindAsync(f => f.FollowerId == userId);

        var followerIds = follows.Select(f => f.FollowedId).ToList();

        var followers = await _unitOfWork.ApplicationUsers.FindAsync(u => followerIds.Contains(u.Id));

        return new ViewFollowsDTO(
             UserId: userId,
             Follows: followers.Select(a =>
                 new ViewUserDTO(
                     FirstName: a.FirstName,
                     MiddleName: a.MiddleName,
                     LastName: a.LastName
                 )).ToList()
         );
    }
}