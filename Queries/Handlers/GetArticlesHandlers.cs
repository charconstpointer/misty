using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Domain.Entities;

namespace Misty.Queries.Handlers
{
    public class GetArticlesHandler : IRequestHandler<GetArticles, IEnumerable<Article>>
    {
        private readonly ICollection<Article> _articles;

        public GetArticlesHandler(ICollection<Article> articles)
        {
            _articles = articles;
        }

        public Task<IEnumerable<Article>> Handle(GetArticles request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_articles.AsEnumerable());
        }
    }
}