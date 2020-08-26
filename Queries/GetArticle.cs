using MediatR;
using Misty.Domain.Entities;

namespace Misty.Queries
{
    public class GetArticle : IRequest<Article>
    {
        public int ArticleId { get; set; }
    }
}