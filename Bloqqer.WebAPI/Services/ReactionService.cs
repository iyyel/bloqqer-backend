using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.WebAPI.Services.Interfaces;

namespace Bloqqer.WebAPI.Services;

public sealed class ReactionService(
    IUnitOfWork _unitOfWork
) : IReactionService
{
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;

}