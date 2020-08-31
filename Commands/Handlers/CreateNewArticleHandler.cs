using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Commands.Articles;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class CreateNewArticleHandler : IRequestHandler<CreateNewArticle>
    {
        private readonly IArticlesRepository _articlesRepository;
        private readonly MistyContext _context;

        public CreateNewArticleHandler(IArticlesRepository articlesRepository, MistyContext context)
        {
            _articlesRepository = articlesRepository;
            _context = context;
        }

        public async Task<Unit> Handle(CreateNewArticle request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(c => c.Id == request.CategoryId,
                cancellationToken);
            var article = Article.Create(request.Title, request.Description, category);
            await _context.Articles.AddAsync(article, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}