using Bloqqer.Application.Exceptions;
using Bloqqer.Domain.Models;
using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Services.Interfaces;

namespace Bloqqer.WebAPI.Services;

public sealed class BloqService(
    IUnitOfWork _unitOfWork,
    IUserService _userService
) : IBloqService
{
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    private readonly IUserService _userService = _userService;

    public async Task<ICollection<BloqMetadataDTO>> GetAllBloqsMetadata()
    {
        return [.. (await _unitOfWork.Bloqs.GetAllAsync())
            .OrderByDescending(b => b.CreatedOn)
            .Select(bloq =>
            new BloqMetadataDTO()
            {
                Id = bloq.Id,
                AuthorId = bloq.AuthorId,
                AuthorFirstName = bloq.Author?.FirstName ?? string.Empty,
                AuthorMiddleName = bloq.Author?.MiddleName ?? string.Empty,
                AuthorLastName = bloq.Author?.LastName ?? string.Empty,
                Title = bloq.Title,
                Description = bloq.Description,
                IsPrivate = bloq.IsPrivate,
                IsPublished = bloq.IsPublished,
                Published = bloq.Published,
                PostCount = bloq.Posts.Count,
                ReactionCount = bloq.Reactions.Count,
            }
        )];
    }

    public async Task<Guid> CreateBloq(CreateBloqDTO createBloq)
    {
        var userId = _userService.GetLoggedInUserId();

        var newBloq = Bloq.Create(
            userId,
            createBloq.Title,
            createBloq.Description,
            userId,
            createBloq.IsPrivate
        );

        await _unitOfWork.Bloqs.AddAsync(newBloq);
        await _unitOfWork.SaveChangesAsync();

        return newBloq.Id;
    }

    public async Task<ViewBloqDTO> GetBloqByBloqId(Guid bloqId)
    {
        var bloq = await _unitOfWork.Bloqs.GetByIdAsync(bloqId)
            ?? throw new NotFoundException($"Bloq with Id ({bloqId}) was not found");

        return new ViewBloqDTO()
        {
            Id = bloq.Id,
            AuthorId = bloq.AuthorId,
            Title = bloq.Title,
            Description = bloq.Description,
            IsPrivate = bloq.IsPrivate,
            IsPublished = bloq.IsPublished,
            Published = bloq.Published,
            Posts = bloq.Posts,
            Reactions = bloq.Reactions,
        };
    }

    public async Task<ICollection<ViewBloqDTO>> GetBloqsByUserId(Guid userId)
    {
        return (await _unitOfWork.Bloqs.FindAsync(b => b.AuthorId == userId))
            .OrderByDescending(b => b.CreatedOn)
            .Select(bloq =>
            new ViewBloqDTO()
            {
                Id = bloq.Id,
                AuthorId = bloq.AuthorId,
                Title = bloq.Title,
                Description = bloq.Description,
                IsPrivate = bloq.IsPrivate,
                IsPublished = bloq.IsPublished,
                Published = bloq.Published,
                Posts = bloq.Posts,
                Reactions = bloq.Reactions,
            }
        ).ToList();
    }

    public async Task<ICollection<ViewBloqDTO>> GetFollowingUsersBloqs()
    {
        var userId = _userService.GetLoggedInUserId();

        var followedIds = (await _unitOfWork.Follows.FindAsync(f => f.FollowerId == userId)).Select(f => f.FollowedId);

        return (await _unitOfWork.Bloqs.FindAsync(b => followedIds.Contains(b.AuthorId)))
            .OrderByDescending(b => b.CreatedOn)
            .Select(bloq =>
            new ViewBloqDTO()
            {
                Id = bloq.Id,
                AuthorId = bloq.AuthorId,
                Title = bloq.Title,
                Description = bloq.Description,
                IsPrivate = bloq.IsPrivate,
                IsPublished = bloq.IsPublished,
                Published = bloq.Published,
            }
        ).ToList();
    }

    public async Task<Guid> UpdateBloq(UpdateBloqDTO updateBloq)
    {
        var loggedInUserId = _userService.GetLoggedInUserId();

        var currentBloq = await _unitOfWork.Bloqs.GetByIdAsync(updateBloq.BloqId)
            ?? throw new NotFoundException($"Bloq with Id ({updateBloq.BloqId}) was not found");

        if (loggedInUserId != currentBloq.AuthorId)
        {
            throw new UnauthorizedException($"Logged in user with Id ({loggedInUserId}) does not own Bloq with author Id ({currentBloq.AuthorId})");
        }

        currentBloq.Title = updateBloq.Title;
        currentBloq.Description = updateBloq.Description;
        currentBloq.IsPrivate = updateBloq.IsPrivate;
        currentBloq.IsPublished = updateBloq.IsPublished;
        currentBloq.Published = !currentBloq.IsPublished && updateBloq.IsPublished ? DateTime.UtcNow : currentBloq.Published;
        currentBloq.ModifiedBy = loggedInUserId;
        currentBloq.ModifiedOn = DateTime.UtcNow;

        _unitOfWork.Bloqs.Update(currentBloq);
        await _unitOfWork.SaveChangesAsync();

        return currentBloq.Id;
    }

    public async Task<Guid> RemoveBloq(Guid bloqId)
    {
        var bloq = await _unitOfWork.Bloqs.GetByIdAsync(bloqId)
            ?? throw new NotFoundException($"Bloq with Id ({bloqId}) was not found");

        _unitOfWork.Bloqs.Remove(bloq);
        await _unitOfWork.SaveChangesAsync();

        return bloq.Id;
    }
}