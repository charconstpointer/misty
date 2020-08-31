using MediatR;
using Misty.Domain.Entities;
using Misty.Domain.Entities.Content;

namespace Misty.Queries
{
    public class GetArticle : IRequest<Article>
    {
        public int ArticleId { get; set; }
    }
}