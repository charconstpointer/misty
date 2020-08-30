using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Commands.Categories;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;

namespace Misty.Commands.Handlers
{
    public class CreateNewCategoryHandler : IRequestHandler<CreateNewCategory>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CreateNewCategoryHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Unit> Handle(CreateNewCategory request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name, request.Description);
            await _categoriesRepository.Save(category);
            return Unit.Value;
        }
    }
}