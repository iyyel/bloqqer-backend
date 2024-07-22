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
        var user = await _unitOfWork.ApplicationUsers.GetByIdAsync(userGuid) ?? throw new ArgumentException("User not found?");

        var newBloq = Bloq.Create(
            userGuid,
            createBloq.Title,
            createBloq.Description,
            createBloq.IsPrivate,
            user.UserName ?? "System"
        );

        await _unitOfWork.Bloqs.AddAsync(newBloq);

        return newBloq.Id;
    }
}