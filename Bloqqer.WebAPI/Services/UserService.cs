using Bloqqer.DataAccess.Repositories.UnitOfWork;
using Bloqqer.DataAccess.Services.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using System.Security.Claims;

namespace Bloqqer.DataAccess.Services;

public sealed class UserService(
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor
) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public async Task<ICollection<UserDTO>> GetAllUsers()
    {
        return (await _unitOfWork.ApplicationUsers.GetAll()).Select(a =>
            new UserDTO
            {
                FirstName = a.FirstName,
                MiddleName = a.MiddleName,
                LastName = a.LastName,
            }).ToList();
    }

    public string? GetLoggedInUser()
    {
        var userId = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return userId;
    }

    public Guid? GetLoggedInUserId()
    {
        var userId = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        bool isValidGuid = Guid.TryParse(userId, out Guid userGuid);
        return isValidGuid ? userGuid : null;
    }
}