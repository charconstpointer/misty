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
using Misty.Queries.Articles;

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
            var articles = await _context.Articles
                .Include(a => a.Ads)
                .Include(a => a.Comments)
                .Include(a => a.Category)
                .Include(a => a.Creator)
                .Include(a => a.ContentVisitors)
                .ToListAsync(cancellationToken);
            return articles.AsDto();
        }
    }
}