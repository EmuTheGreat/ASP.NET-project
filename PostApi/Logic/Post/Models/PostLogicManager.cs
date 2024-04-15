using Dal.Post.Interfaces;
using Dal.Post.Models;
using Logic.Post.Interface;

namespace Logic.Post.Models
{
    public class PostLogicManager : IPostLogicManager
    {
        private readonly IPostRepository _repository;

        public PostLogicManager(IPostRepository repository)
        {
            _repository = repository;
        }
        public async Task<uint> CreatePostAsync(PostLogic post)
        {
            return await _repository.CreatePostAsync(post.AuthorId, post.Content);
        }

        public async Task<PostDal[]> GetFeedAsync(uint[] FriendsId)
        {
            var Friends = new HashSet<uint>(FriendsId);
            return await _repository.GetFeedAsync(Friends);
        }

        public async Task<PostDal[]> GetPostsAsync(uint AuthorID)
        {
           return await _repository.GetPostsAsync(AuthorID);
        }
    }
}
