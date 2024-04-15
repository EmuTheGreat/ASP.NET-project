using System.ComponentModel.DataAnnotations;

namespace Dal.Post.Models
{
    public class PostCounterDal
    {
        /// <summary>
        /// Wall owner id
        /// </summary>
        [Key]
        public uint AuthorId { get; set; }

        /// <summary>
        /// Number of posts and comments on the wall
        /// </summary>
        public uint PostCount { get; set; }
    }
}
