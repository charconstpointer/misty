using System;

namespace Misty.Dto
{
    public class CommentDto
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Author { get; set; }
        public DateTime LastChangedAt { get; set; }
    }
}