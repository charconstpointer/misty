using MediatR;

namespace Misty.Commands
{
    public class DeleteArticle : IRequest
    {
        public int ArticleId { get; set; }
    }
}