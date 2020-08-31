using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Commands.Categories;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategory>
    {
        private readonly MistyContext _context;

        public DeleteCategoryHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCategory request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(c => c.Id == request.CategoryId,
                cancellationToken: cancellationToken);
            if (category == null)
            {
                throw new ApplicationException($"Category with id {request.CategoryId} could not be found");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}