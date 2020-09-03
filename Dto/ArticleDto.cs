using System;
using System.Collections.Generic;

namespace Misty.Dto
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Creator { get; set; }
        public int ViewCount { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<string> Comments { get; set; }
        public IEnumerable<string> Ads { get; set; }
        public string Ad { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}