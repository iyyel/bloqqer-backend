using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services.Interfaces;

public interface IBloqService
{
    Task<Guid> CreateBloq(CreateBloqDTO bloq);
}