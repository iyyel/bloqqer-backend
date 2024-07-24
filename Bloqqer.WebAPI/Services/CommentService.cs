using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.WebAPI.Services.Interfaces;

namespace Bloqqer.WebAPI.Services;

public sealed class CommentService(
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor
) : ICommentService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

}