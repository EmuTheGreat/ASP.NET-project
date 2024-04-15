using Dal.Post.Contexts;
using Dal.Post.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Post.Models
{
    public class PostRepository : IPostRepository
    {
        public PostRepository()
        {
            
        }
        public async Task<uint> CreatePostAsync(uint AuthorId, string Content)
        {
            using (var db = new PostContext())
            {
                var postCounter = await db.Counter.FindAsync(AuthorId);
                if (postCounter is null)
                {
                    postCounter = new PostCounterDal { AuthorId = AuthorId, PostCount = 1 };
                    await db.Counter.AddAsync(postCounter);
                }
                else
                {
                    postCounter.PostCount++;
                    db.Counter.Update(postCounter);
                }
                var post = new PostDal { AuthorId = AuthorId, Id = postCounter.PostCount, Content = Content };
                await db.Posts.AddAsync(post);
                await db.SaveChangesAsync();
                return post.Id;
            }
        }

        public async Task<PostDal[]> GetFeedAsync(HashSet<uint> FriendsID)
        {
            //var threeDays = TimeSpan.FromDays(3);
            using var db = new PostContext();
            return await (db.Posts.Where(post => FriendsID.Contains(post.AuthorId) && (DateTime.UtcNow - post.Time ).Days < 3)
                .OrderByDescending(post => post.Time)
                ?.ToArrayAsync() ?? Task.FromResult(Array.Empty<PostDal>()));
        }

        public async Task<PostDal[]> GetPostsAsync(uint AuthorID)
        {
            using var db = new PostContext();
            return await (db.Posts.Where(x => x.AuthorId == AuthorID)?.ToArrayAsync() ?? Task.FromResult(Array.Empty<PostDal>()));
        }
    }
}
