using MediatR;
using Misty.Domain.Entities.Content;
using Misty.Dto;

namespace Misty.Queries
{
    public class GetArticle : IRequest<ArticleDto>
    {
        public int ArticleId { get; set; }
    }
}