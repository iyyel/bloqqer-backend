using Bloqqer.Application.Exceptions;
using Bloqqer.Domain.Models;
using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Services.Interfaces;
using System.Security.Claims;

namespace Bloqqer.WebAPI.Services;

public sealed class UserService(
    IUnitOfWork _unitOfWork,
    IHttpContextAccessor _httpContextAccessor
) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor = _httpContextAccessor;

    public Guid GetLoggedInUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        bool isValidGuid = Guid.TryParse(userId, out Guid userGuid);
        return isValidGuid
            ? userGuid
            : throw new UnauthorizedException("User is not logged in");
    }

    public async Task<ApplicationUser> GetLoggedInUser()
    {
        var userId = GetLoggedInUserId();

        var user = await _unitOfWork.ApplicationUsers.SingleOrDefaultAsync(a => a.Id == userId)
            ?? throw new NotFoundException($"User with Id ({userId}) was not found");

        return user;
    }

    public async Task<ApplicationUser> GetUserByUserId(Guid userId)
    {
        return await _unitOfWork.ApplicationUsers.GetByIdAsync(userId)
            ?? throw new NotFoundException($"User with Id ({userId}) was not found");
    }

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
}