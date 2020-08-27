using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;

namespace Misty.Queries.Handlers
{
    public class GetArticlesHandler : IRequestHandler<GetArticles, IEnumerable<Article>>
    {
        private readonly IArticlesRepository _articlesRepository;

        public GetArticlesHandler(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public async Task<IEnumerable<Article>> Handle(GetArticles request, CancellationToken cancellationToken)
        {
            return await _articlesRepository.GetAll();
        }
    }
}