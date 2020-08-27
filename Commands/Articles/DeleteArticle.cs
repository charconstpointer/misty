using MediatR;

namespace Misty.Commands.Articles
{
    public class DeleteArticle : IRequest
    {
        public int ArticleId { get; set; }
    }
}