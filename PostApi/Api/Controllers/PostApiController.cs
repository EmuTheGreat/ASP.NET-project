using Api.Post.Request;
using Api.Post.Response;
using Logic.Post.Interface;
using Logic.Post.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace PostApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostApiController : ControllerBase
    {

        private readonly IPostLogicManager _postLogicManager;

        public PostApiController(IPostLogicManager postLogicManager)
        {
            _postLogicManager = postLogicManager;
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType<PostResponse[]>(200)]
        public async Task<IActionResult> GetPostsAsync([Range(1, uint.MaxValue, ErrorMessage ="Should be positive")]uint AuthorID)
        {
            var posts = await _postLogicManager.GetPostsAsync(AuthorID);
            var postsResponse = posts.Select(post => new PostResponse()
            {
                AuthorId = post.AuthorId,
                Id = post.Id,
                Content = post.Content,
                Time = post.Time,
                ViewCount = post.ViewCount,
                RepostCount = post.RepostCount,
                LikeCount = post.LikeCount,
            })
            .ToArray();

            return Ok(posts);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetCommentsAsync(uint AuthorID, uint PostId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType<CreatePostResponse>(201)]
        public async Task<IActionResult> CreatePostAsync(CreatePostRequest dto)
        {
            var res = await _postLogicManager.CreatePostAsync(new PostLogic
            {
                AuthorId = dto.AuthorId,
                Content = dto.Content
            });
            return new ObjectResult(new CreatePostResponse
            {
                Id = res
            })
            {
                StatusCode = 201
            };
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType<PostResponse[]>(200)]
        public async Task<IActionResult> GetFeedAsync([FromQuery]uint[] FriendsId)
        {
            var posts = await _postLogicManager.GetFeedAsync(FriendsId);
            var postsResponse = posts.Select(post => new PostResponse()
            {
                AuthorId = post.AuthorId,
                Id = post.Id,
                Content = post.Content,
                Time = post.Time,
                ViewCount = post.ViewCount,
                RepostCount = post.RepostCount,
                LikeCount = post.LikeCount,
            })
            .ToArray();

            return Ok(posts);
        }
    }
}
