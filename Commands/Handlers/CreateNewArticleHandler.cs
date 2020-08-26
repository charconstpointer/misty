using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Domain.Entities;

namespace Misty.Commands.Handlers
{
    public class CreateNewArticleHandler : IRequestHandler<CreateNewArticle>
    {
        private readonly ICollection<Article> _articles;

        public CreateNewArticleHandler(ICollection<Article> articles)
        {
            _articles = articles;
        }

        public Task<Unit> Handle(CreateNewArticle request, CancellationToken cancellationToken)
        {
            var article = Article.Create(request.Title, request.Description);
            _articles.Add(article);
            return Unit.Task;
        }
    }
}