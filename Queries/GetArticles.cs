using System.Collections.Generic;
using MediatR;
using Misty.Domain.Entities;
using Misty.Domain.Entities.Content;

namespace Misty.Queries
{
    public class GetArticles : IRequest<IEnumerable<Article>>
    {
        public int CategoryId { get; set; }
    }
}