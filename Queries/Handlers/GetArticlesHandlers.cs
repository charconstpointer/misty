using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;
using Misty.Persistence;

namespace Misty.Queries.Handlers
{
    public class GetArticlesHandler : IRequestHandler<GetArticles, IEnumerable<Article>>
    {
        private readonly IArticlesRepository _articlesRepository;
        private readonly MistyContext _context;

        public GetArticlesHandler(IArticlesRepository articlesRepository, MistyContext context)
        {
            _articlesRepository = articlesRepository;
            _context = context;
        }

        public async Task<IEnumerable<Article>> Handle(GetArticles request, CancellationToken cancellationToken)
        {
            var articles = await _context.Articles
                .Include(a => a.Ads)
                .Include(a => a.Comments)
                .Include(a => a.Category)
                .ToListAsync(cancellationToken: cancellationToken);
            return articles;
        }
    }
}