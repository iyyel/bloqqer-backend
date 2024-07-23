using Bloqqer.Infrastructure.Models;
using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Services.Interfaces;

namespace Bloqqer.WebAPI.Services;

public sealed class BloqService(
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor,
    IUserService userService
) : IBloqService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IUserService _userService = userService;

    public async Task<Guid> CreateBloq(CreateBloqDTO createBloq)
    {
        var userGuid = _userService.GetLoggedInUserId() ?? throw new ArgumentException("Not logged in?");

        var newBloq = Bloq.Create(
            userGuid,
            createBloq.Title,
            createBloq.Description,
            userGuid,
            createBloq.IsPrivate
        );

        await _unitOfWork.Bloqs.AddAsync(newBloq);
        await _unitOfWork.SaveChangesAsync();

        return newBloq.Id;
    }

    public async Task<ICollection<ViewBloqDTO>> GetBloqsByUserId(Guid id)
    {
        // TODO: How do I make it so the Posts are included in the in the output as well?
        return (await _unitOfWork.Bloqs.FindAsync(b => b.AuthorId == id))
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
                Posts = b.Posts,
            }
        ).ToList();
    }

    public async Task<Guid> UpdateBloq(UpdateBloqDTO updateBloq)
    {
        // TODO: Make exception handling better.
        var userGuid = _userService.GetLoggedInUserId() ?? throw new ArgumentException("Not logged in?");
        var oldBloq = await _unitOfWork.Bloqs.GetByIdAsync(updateBloq.BloqId) ?? throw new ArgumentException("Bloq not found?");

        if (userGuid != oldBloq.AuthorId)
        {
            throw new Exception("You can't update somebody else's bloq!");
        }

        var user = await _unitOfWork.ApplicationUsers.GetByIdAsync(userGuid) ?? throw new ArgumentException("User not found?");

        oldBloq.Title = updateBloq.Title;
        oldBloq.Description = updateBloq.Description;
        oldBloq.IsPrivate = updateBloq.IsPrivate;
        oldBloq.IsPublished = updateBloq.IsPublished;
        oldBloq.Published = !oldBloq.IsPublished && updateBloq.IsPublished ? DateTime.UtcNow : oldBloq.Published;
        oldBloq.ModifiedBy = user.Id;
        oldBloq.ModifiedOn = DateTime.UtcNow;

        _unitOfWork.Bloqs.Update(oldBloq);
        await _unitOfWork.SaveChangesAsync();

        return oldBloq.Id;
    }
}