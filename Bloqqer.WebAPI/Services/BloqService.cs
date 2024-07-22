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

    public async Task<Guid> Create(CreateBloqDTO createBloq)
    {
        var userGuid = _userService.GetLoggedInUserId() ?? throw new ArgumentException("Not logged in?");
        var user = await _unitOfWork.ApplicationUsers.GetByIdAsync(userGuid) ?? throw new ArgumentException("User not found?");

        var newBloq = Bloq.Create(
            userGuid,
            createBloq.Title,
            createBloq.Description,
            user.UserName ?? "System",
            createBloq.IsPrivate
        );

        await _unitOfWork.Bloqs.AddAsync(newBloq);
        await _unitOfWork.SaveChangesAsync();

        return newBloq.Id;
    }

    public async Task<ICollection<ViewBloqDTO>> GetByUserId(Guid id)
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

    public async Task<ICollection<ViewBloqDTO>> GetAll()
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

    // TODO: Debug this method.
    public async Task<Guid> Update(UpdateBloqDTO updateBloq)
    {
        // TODO: Make exception handling better.
        var userGuid = _userService.GetLoggedInUserId() ?? throw new ArgumentException("Not logged in?");
        var oldBloq = await _unitOfWork.Bloqs.GetByIdAsync(updateBloq.BloqId) ?? throw new ArgumentException("Bloq not found?");

        if (userGuid != oldBloq.AuthorId)
        {
            throw new Exception("You can't update somebody else's bloq!");
        }

        var user = await _unitOfWork.ApplicationUsers.GetByIdAsync(userGuid) ?? throw new ArgumentException("User not found?");
        // TODO: Use AutoMapper for this stuff.
        _unitOfWork.Bloqs.Update(
            new Bloq()
            {
                Id = oldBloq.Id,
                AuthorId = oldBloq.AuthorId,
                Title = updateBloq.Title,
                Description = updateBloq.Description,
                IsPrivate = updateBloq.IsPrivate,
                IsPublished = updateBloq.IsPublished,
                Published = !oldBloq.IsPublished && updateBloq.IsPublished ? DateTime.UtcNow : oldBloq.Published,
                Posts = oldBloq.Posts,
                CreatedBy = oldBloq.CreatedBy,
                CreatedOn = oldBloq.CreatedOn,
                ModifiedBy = user.UserName,
                ModifiedOn = DateTime.UtcNow,
                DeletedBy = oldBloq.DeletedBy,
                DeletedOn = oldBloq.DeletedOn,
            }
        );

        await _unitOfWork.SaveChangesAsync();

        return oldBloq.Id;
    }
}