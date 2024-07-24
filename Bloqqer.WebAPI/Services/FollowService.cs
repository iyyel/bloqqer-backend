using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.WebAPI.Services.Interfaces;

namespace Bloqqer.WebAPI.Services;

public sealed class FollowService(
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor
) : IFollowService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

}