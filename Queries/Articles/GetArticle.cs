using MediatR;
using Misty.Dto;

namespace Misty.Queries.Articles
{
    public class GetArticle : IRequest<ArticleDto>
    {
        public int ArticleId { get; set; }
    }
}