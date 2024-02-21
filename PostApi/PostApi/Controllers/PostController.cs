using Microsoft.AspNetCore.Mvc;

namespace PostApi.Controllers
{
    public class PostController : ControllerBase
    {
        [Route("[action]")]
        [HttpPost]
        /// <summary>
        /// Create a post.
        /// </summary>
        public async Task<IActionResult> CreatePost(uint AuthorId, string Text)
        {
            throw new NotImplementedException();
        }

        [Route("[action]")]
        [HttpGet]
        /// <summary>
        /// Get all posts by the author.
        /// </summary>
        public async Task<IActionResult> GetPostsAsync(uint AuthorID)
        {
            throw new NotImplementedException();
        }

        [Route("[action]")]
        [HttpGet]
        /// <summary>
        /// Get post comments.
        /// </summary>
        public async Task<IActionResult> GetCommentsAsync(uint AuthorID, uint PostId)
        {
            throw new NotImplementedException();
        }
    }
}
