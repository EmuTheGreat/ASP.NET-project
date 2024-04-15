using System.ComponentModel.DataAnnotations;

namespace Api.Post.Request
{
    public class CreatePostRequest
    {
        [Range(1, uint.MaxValue, ErrorMessage = "AuthorId should be positive")]
        public required uint AuthorId { get; set; }
        [Required]
        public required string Content { get; set; }

    }
}
