using Microsoft.AspNetCore.Mvc;

namespace PostApi.Controllers
{
    public class PostController : ControllerBase
    {
        [Route("[action]")]
        [HttpPost]
        /// <summary>
        /// Создать пост.
        /// </summary>
        public async Task<IActionResult> CreatePost(uint AuthorId, string Text)
        {
            throw new NotImplementedException();
        }

        [Route("[action]")]
        [HttpGet]
        /// <summary>
        /// Получить все посты автора.
        /// </summary>
        public async Task<IActionResult> GetPostsAsync(uint AuthorID)
        {
            throw new NotImplementedException();
        }

        [Route("[action]")]
        [HttpGet]
        /// <summary>
        /// Получить комментарии поста.
        /// </summary>
        public async Task<IActionResult> GetCommentsAsync(uint AuthorID, uint PostId)
        {
            throw new NotImplementedException();
        }
    }
}
