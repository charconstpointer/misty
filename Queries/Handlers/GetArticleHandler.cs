using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;

namespace Misty.Queries.Handlers
{
    public class GetArticleHandler : IRequestHandler<GetArticle, Article>
    {
        private readonly IArticlesRepository _articlesRepository;

        public GetArticleHandler(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public async Task<Article> Handle(GetArticle request, CancellationToken cancellationToken)
        {
            return await _articlesRepository.Get(request.ArticleId);
        }
    }
}