﻿using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services.Interfaces;

public interface IBloqService
{
    Task<ICollection<BloqMetadataDTO>> GetAllBloqsMetadata();

    Task<Guid> CreateBloq(CreateBloqDTO createBloq);

    Task<ViewBloqDTO> GetBloqByBloqId(Guid bloqId);

    Task<ICollection<ViewBloqDTO>> GetBloqsByUserId(Guid userId);

    Task<ICollection<ViewBloqDTO>> GetFollowingUsersBloqs();

    Task<Guid> UpdateBloq(UpdateBloqDTO updateBloq);

    Task<Guid> RemoveBloq(Guid bloqId);
}