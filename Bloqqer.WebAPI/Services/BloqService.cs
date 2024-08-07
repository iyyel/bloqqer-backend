﻿using Bloqqer.Application.Exceptions;
using Bloqqer.Domain.Models;
using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Services.Interfaces;

namespace Bloqqer.WebAPI.Services;

public sealed class BloqService(
    IUnitOfWork _unitOfWork,
    IUserService userService
) : IBloqService
{
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    private readonly IUserService _userService = userService;

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
            BloqId = bloq.Id,
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
        _ = await _userService.GetUserByUserId(userId);

        return (await _unitOfWork.Bloqs.FindAsync(b => b.AuthorId == userId))
            .Select(b =>
            new ViewBloqDTO()
            {
                BloqId = b.Id,
                AuthorId = b.AuthorId,
                Title = b.Title,
                Description = b.Description,
                IsPrivate = b.IsPrivate,
                IsPublished = b.IsPublished,
                Published = b.Published,
                Posts = b.Posts,
                Reactions = b.Reactions,
            }
        ).ToList();
    }

    public async Task<ICollection<ViewBloqDTO>> GetAllBloqs()
    {
        return (await _unitOfWork.Bloqs.GetAllAsync())
            .Select(b =>
            new ViewBloqDTO()
            {
                BloqId = b.Id,
                AuthorId = b.AuthorId,
                Title = b.Title,
                Description = b.Description,
                IsPrivate = b.IsPrivate,
                IsPublished = b.IsPublished,
                Published = b.Published,
            }
        ).ToList();
    }

    public Task<ICollection<ViewBloqDTO>> GetFollowedUsersBloqs()
    {
        throw new NotImplementedException();
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