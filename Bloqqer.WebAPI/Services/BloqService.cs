using Bloqqer.DataAccess.Models;
using Bloqqer.DataAccess.Repositories.UnitOfWork;
using Bloqqer.DataAccess.Services.Interfaces;
using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.DataAccess.Services;

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
        var user = await _unitOfWork.ApplicationUsers.Get(userGuid) ?? throw new ArgumentException("User not found?");

        var newBloq = Bloq.Create(
            userGuid,
            user,
            createBloq.Title,
            createBloq.Description,
            createBloq.IsPrivate,
            user.UserName ?? "System"
        );

        await _unitOfWork.Bloqs.Add(newBloq);

        return newBloq.Id;
    }
}