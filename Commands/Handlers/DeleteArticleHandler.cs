using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Commands.Articles;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;

namespace Misty.Commands.Handlers
{
    public class DeleteArticleHandler : IRequestHandler<DeleteArticle>
    {
        private readonly IArticlesRepository _articlesRepository;

        public DeleteArticleHandler(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public async Task<Unit> Handle(DeleteArticle request, CancellationToken cancellationToken)
        {
            await _articlesRepository.Delete(request.ArticleId);
            return Unit.Value;
        }
    }
}