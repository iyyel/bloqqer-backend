using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services.Interfaces;

public interface IPostService
{

    // Create Post (logged in user creates it, on a specified bloq iq, logged in user is author)

    // Get posts by user (gets all posts made by a specific user, user id)

    // get all posts (gets all posts)

    // get all posts from a bloq (bloq id)

    // update a post

    // remove a post
    Task<Guid> CreatePost(CreatePostDTO createPost);
}