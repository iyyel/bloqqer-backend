using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services.Interfaces;

public interface IBloqService
{
    Task<Guid> Create(CreateBloqDTO createBloq);

    Task<ICollection<ViewBloqDTO>> GetByUserId(Guid id);

    Task<ICollection<ViewBloqDTO>> GetAll();

    Task<Guid> Update(UpdateBloqDTO updateBloq);
}