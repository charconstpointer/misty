using System.Collections.Generic;
using MediatR;

namespace Misty.Commands.Articles
{
    public class UpdateArticle : IRequest
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }
        public bool Ads { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}