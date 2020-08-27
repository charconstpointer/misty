using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;

namespace Misty.Queries.Handlers
{
    public class GetArticleCommentsHandler : IRequestHandler<GetArticleComments, IEnumerable<Comment>>
    {
        private readonly IArticlesRepository _articlesRepository;

        public GetArticleCommentsHandler(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public async Task<IEnumerable<Comment>> Handle(GetArticleComments request, CancellationToken cancellationToken)
        {
            var article = await _articlesRepository.Get(request.ArticleId);
            var comments = article.Comments;
            return comments;
        }
    }
}