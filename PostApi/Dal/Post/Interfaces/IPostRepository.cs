using Dal.Post.Models;

namespace Dal.Post.Interfaces
{
    public interface IPostRepository
    {
        Task<uint> CreatePostAsync(uint AuthorId, string Content);
        Task<PostDal[]> GetPostsAsync(uint AuthorID);

        Task<PostDal[]> GetFeedAsync(HashSet<uint> FriendsID);
    }
}
