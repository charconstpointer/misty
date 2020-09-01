using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities.Content;
using Misty.Persistence;
using Misty.Queries.Categories;

namespace Misty.Queries.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategories, IEnumerable<Category>>
    {
        private readonly MistyContext _context;

        public GetCategoriesHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> Handle(GetCategories request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.ToListAsync(cancellationToken);
            return categories;
        }
    }
}