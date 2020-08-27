using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Commands.Categories;

namespace Misty.Commands.Handlers
{
    public class CreateNewCategoryHandler : IRequestHandler<CreateNewCategory>
    {
        public async Task<Unit> Handle(CreateNewCategory request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}