using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Post.Models
{
    public class PostDal
    {
        /// <summary>
        /// The id is individually calculated for each user's wall
        /// </summary>
        public required uint Id { get; init; }
        /// <summary>
        /// The author id with the post id form the primary key
        /// </summary>
        public required uint AuthorId { get; init; }
        /// <summary>
        /// creation time
        /// </summary>
        public DateTime Time { get; init; } = DateTime.UtcNow;
        /// <summary>
        /// Post content
        /// </summary>
        public required string Content { get; init; }
        /// <summary>
        /// Number of reposts
        /// </summary>
        public uint RepostCount { get; init; } = 0;
        /// <summary>
        /// Number of likes
        /// </summary>
        public uint LikeCount { get; init; } = 0;
        /// <summary>
        /// Number of views
        /// </summary>
        public uint ViewCount { get; init; } = 0;
        /// <summary>
        /// (id, authorId) link to the parent post, if id == 0, it means an independent post, otherwise a comment
        /// </summary>
        //[ForeignKey("source")]
        //public (uint, uint) Source { get; init; }

    }
}
