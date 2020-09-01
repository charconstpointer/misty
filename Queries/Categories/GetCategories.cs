using System.Collections.Generic;
using MediatR;
using Misty.Domain.Entities.Content;

namespace Misty.Queries.Categories
{
    public class GetCategories : IRequest<IEnumerable<Category>>
    {
    }
}