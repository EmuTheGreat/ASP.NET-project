using Dal.Post.Models;
using Logic.Post.Models;

namespace Logic.Post.Interface
{
    public interface IPostLogicManager
    {
        Task<uint> CreatePostAsync(PostLogic post);
        Task<PostDal[]> GetPostsAsync(uint AuthorID);
        Task<PostDal[]> GetFeedAsync(uint[] FriendsId);
    }
}
