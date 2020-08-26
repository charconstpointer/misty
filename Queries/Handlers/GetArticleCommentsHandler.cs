using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Domain.Entities;

namespace Misty.Queries.Handlers
{
    public class GetArticleCommentsHandler : IRequestHandler<GetArticleComments, IEnumerable<Comment>>
    {
        private readonly ICollection<Article> _articles;

        public GetArticleCommentsHandler(ICollection<Article> articles)
        {
            _articles = articles;
        }

        public Task<IEnumerable<Comment>> Handle(GetArticleComments request, CancellationToken cancellationToken)
        {
            var comments = _articles.FirstOrDefault(a => a.Id == request.ArticleId)
                ?.Comments.AsEnumerable();
            return Task.FromResult(comments);
        }
    }
}