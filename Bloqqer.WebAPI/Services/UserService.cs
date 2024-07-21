using Bloqqer.DataAccess.Repositories.UnitOfWork;
using Bloqqer.DataAccess.Services.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using System.Security.Claims;

namespace Bloqqer.DataAccess.Services;

public sealed class UserService(
    IUnitOfWork _unitOfWork,
    IHttpContextAccessor _httpContextAccessor
) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor = _httpContextAccessor;

    public async Task<ICollection<UserDTO>> GetAllUsers()
    {
        return (await _unitOfWork.ApplicationUsers.GetAllAsync()).Select(a =>
            new UserDTO
            {
                FirstName = a.FirstName,
                MiddleName = a.MiddleName,
                LastName = a.LastName,
            }).ToList();
    }

    public string? GetLoggedInUser()
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return userId;
    }

    public Guid? GetLoggedInUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        bool isValidGuid = Guid.TryParse(userId, out Guid userGuid);
        return isValidGuid ? userGuid : null;
    }
}