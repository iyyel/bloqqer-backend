using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services.Interfaces;

public interface IBloqService
{
    Task<Guid> CreateBloq(CreateBloqDTO createBloq);

    Task<ViewBloqDTO> GetBloqByBloqId(Guid bloqId);

    Task<ICollection<ViewBloqDTO>> GetBloqsByUserId(Guid userId);

    Task<ICollection<ViewBloqDTO>> GetAllBloqs();

    Task<ICollection<ViewBloqDTO>> GetFollowedUsersBloqs();

    Task<Guid> UpdateBloq(UpdateBloqDTO updateBloq);

    Task<Guid> RemoveBloq(Guid bloqId);
}