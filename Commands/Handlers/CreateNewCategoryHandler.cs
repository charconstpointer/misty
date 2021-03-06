using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Commands.Categories;
using Misty.Domain.Entities.Content;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class CreateNewCategoryHandler : IRequestHandler<CreateNewCategory>
    {
        private readonly MistyContext _context;

        public CreateNewCategoryHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateNewCategory request, CancellationToken cancellationToken)
        {
            var exists = _context.Categories.Any(c => c.Name.ToLower() == request.Name.ToLower());
            if (exists)
            {
                throw new ApplicationException("Category with this name already exists");
            }
            var category = new Category(request.Name, request.Description);
            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}