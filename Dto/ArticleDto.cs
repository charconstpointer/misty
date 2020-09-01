using System;
using System.Collections.Generic;

namespace Misty.Dto
{
    public class ArticleDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Creator { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<string> Comments { get; set; }
        public IEnumerable<string> Ads { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}