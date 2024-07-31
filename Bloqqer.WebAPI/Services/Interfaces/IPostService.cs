using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services.Interfaces;

public interface IPostService
{
    Task<Guid> CreatePost(CreatePostDTO createPost);

    Task<ViewPostDTO> GetPostByPostId(Guid postId);

    Task<ICollection<ViewPostDTO>> GetPostsByBloqId(Guid bloqId);

    Task<Guid> UpdatePost(UpdatePostDTO updatePost);

    Task<Guid> RemovePost(Guid postId);
}