using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Post.Models
{
    public class PostLogic
    {
        public required uint AuthorId { get; set; }
        public required string Content { get; set; }
    }
}
