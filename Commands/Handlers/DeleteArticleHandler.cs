using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Commands.Articles;
using Misty.Domain.Entities;

namespace Misty.Commands.Handlers
{
    public class DeleteArticleHandler : IRequestHandler<DeleteArticle>
    {
        private readonly ICollection<Article> _articles;

        public DeleteArticleHandler(ICollection<Article> articles)
        {
            _articles = articles;
        }

        public async Task<Unit> Handle(DeleteArticle request, CancellationToken cancellationToken)
        {
            var article = _articles.FirstOrDefault(a => a.Id == request.ArticleId);
            if (article is null)
                throw new ApplicationException($"Article with id {request.ArticleId} could not be found.");

            _articles.Remove(article);
            return Unit.Value;
        }
    }
}