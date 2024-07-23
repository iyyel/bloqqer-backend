using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services.Interfaces;

public interface IBloqService
{
    Task<Guid> CreateBloq(CreateBloqDTO createBloq);

    Task<ICollection<ViewBloqDTO>> GetBloqsByUserId(Guid id);

    Task<ICollection<ViewBloqDTO>> GetAllBloqs();

    Task<Guid> UpdateBloq(UpdateBloqDTO updateBloq);
}