using System.Collections.Generic;
using MediatR;
using Misty.Domain.Entities;

namespace Misty.Queries.Categories
{
    public class GetCategories : IRequest<IEnumerable<Category>>
    {
        
    }
}