using System.Collections.Generic;
using MediatR;
using Misty.Dto;

namespace Misty.Queries.Articles
{
    public class GetArticlesByCategory : IRequest<IEnumerable<ArticleDto>>
    {
        public GetArticlesByCategory(int categoryId)
        {
            CategoryId = categoryId;
        }

        public int CategoryId { get; set; }
    }
}