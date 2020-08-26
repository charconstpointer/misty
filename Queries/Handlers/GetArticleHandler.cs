using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Domain.Entities;

namespace Misty.Queries.Handlers
{
    public class GetArticleHandler : IRequestHandler<GetArticle, Article>
    {
        private readonly ICollection<Article> _articles;

        public GetArticleHandler(ICollection<Article> articles)
        {
            _articles = articles;
        }

        public async Task<Article> Handle(GetArticle request, CancellationToken cancellationToken)
        {
            var article = _articles.FirstOrDefault(a => a.Id == request.ArticleId);
            return article;
        }
    }
}