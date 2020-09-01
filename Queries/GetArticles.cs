using System.Collections.Generic;
using MediatR;
using Misty.Domain.Entities.Content;
using Misty.Dto;

namespace Misty.Queries
{
    public class GetArticles : IRequest<IEnumerable<ArticleDto>>
    {
        public int CategoryId { get; set; }
    }
}