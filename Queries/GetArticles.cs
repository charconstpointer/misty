using System.Collections.Generic;
using MediatR;
using Misty.Domain.Entites;

namespace Misty.Queries
{
    public class GetArticles : IRequest<IEnumerable<Article>>
    {

    }
}