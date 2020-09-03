using System.Collections.Generic;
using MediatR;
using Misty.Dto;

namespace Misty.Queries.Articles
{
    public class GetArticles : IRequest<IEnumerable<ArticleDto>>
    {
        public int CategoryId { get; set; }
    }
}