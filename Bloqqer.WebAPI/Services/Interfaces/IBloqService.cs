using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.DataAccess.Services.Interfaces;

public interface IBloqService
{
    Task<Guid> CreateBloq(CreateBloqDTO bloq);
}