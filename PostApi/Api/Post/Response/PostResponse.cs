using System.ComponentModel.DataAnnotations;

namespace Api.Post.Response
{
    public class PostResponse
    {
        public required uint Id { get; init; }
        public required uint AuthorId { get; init; }
        
        public required DateTime Time { get; init; }
        [Required]
        public required string Content { get; init; }
        public required uint RepostCount { get; init; }
        public required uint LikeCount { get; init; }
        public required uint ViewCount { get; init; }
    }
}
