using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities;
using Misty.Domain.Entities.Content;
using Misty.Persistence;

namespace Misty.Queries.Handlers
{
    public class GetArticlesHandler : IRequestHandler<GetArticles, IEnumerable<Article>>
    {
        private readonly MistyContext _context;

        public GetArticlesHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> Handle(GetArticles request, CancellationToken cancellationToken)
        {
            var filterByCategory = request.CategoryId > 0;
            IEnumerable<Article> articles;
            if (filterByCategory)
            {
                articles = await _context.Articles
                    .Include(a => a.Ads)
                    .Include(a => a.Comments)
                    .Include(a => a.Category)
                    .Where(a=>a.Category.Id == request.CategoryId)
                    .ToListAsync(cancellationToken: cancellationToken);
                return articles;
            }

            articles = await _context.Articles
                .Include(a => a.Ads)
                .Include(a => a.Comments)
                .Include(a => a.Category)
                .Include(a=>a.Tags)
                .ToListAsync(cancellationToken: cancellationToken);
            return articles;
        }
    }
}