using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Commands.Articles;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;

namespace Misty.Commands.Handlers
{
    public class CreateNewArticleHandler : IRequestHandler<CreateNewArticle>
    {
        private readonly IArticlesRepository _articlesRepository;

        public CreateNewArticleHandler(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public async Task<Unit> Handle(CreateNewArticle request, CancellationToken cancellationToken)
        {
            var article = Article.Create(request.Title, request.Description);
            await _articlesRepository.Save(article);
            return Unit.Value;
        }
    }
}