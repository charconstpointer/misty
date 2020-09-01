using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities.Content;
using Misty.Dto;
using Misty.Extensions.Mappings;
using Misty.Persistence;

namespace Misty.Queries.Handlers
{
    public class GetArticlesHandler : IRequestHandler<GetArticles, IEnumerable<ArticleDto>>
    {
        private readonly MistyContext _context;

        public GetArticlesHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ArticleDto>> Handle(GetArticles request, CancellationToken cancellationToken)
        {
            var filterByCategory = request.CategoryId > 0;
            IEnumerable<Article> articles;
            if (filterByCategory)
            {
                articles = await _context.Articles
                    .Include(a => a.Ads)
                    .Include(a => a.Comments)
                    .Include(a => a.Category)
                    .Include(a=>a.Creator)
                    .Where(a => a.Category.Id == request.CategoryId)
                    .ToListAsync(cancellationToken);
                return articles.AsDto();
            }

            articles = await _context.Articles
                .Include(a => a.Ads)
                .Include(a => a.Comments)
                .Include(a => a.Category)
                .Include(a=>a.Creator)
                .ToListAsync(cancellationToken);
            return articles.AsDto();
        }
    }
}