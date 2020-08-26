using System.Collections.Generic;
using MediatR;
using Misty.Domain.Entities;

namespace Misty.Queries
{
    public class GetArticles : IRequest<IEnumerable<Article>>
    {

    }
}