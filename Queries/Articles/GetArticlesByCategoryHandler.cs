using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Misty.Dto;
using Misty.Extensions.Mappings;
using Misty.Persistence;

namespace Misty.Queries.Articles
{
    public class GetArticlesByCategoryHandler : IRequestHandler<GetArticlesByCategory, IEnumerable<ArticleDto>>
    {
        private readonly MistyContext _context;
        private readonly ILogger<GetArticlesByCategoryHandler> _logger;

        public GetArticlesByCategoryHandler(MistyContext context, ILogger<GetArticlesByCategoryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<ArticleDto>> Handle(GetArticlesByCategory request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Received request for articles in category {request.CategoryId}");
            var category = await _context.Categories
                .Include(c => c.Contents)
                .ThenInclude(c => c.Ads)
                .Include(c => c.Contents)
                .ThenInclude(c => c.Comments)
                .Include(c => c.Contents)
                .ThenInclude(c => c.Creator).Include(c => c.Contents)
                .ThenInclude(c => c.ContentVisitors)
                .FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken: cancellationToken);
            _logger.LogInformation($"Found {category.Contents.Count} contents for category {request.CategoryId}");
            return category.Contents.AsDto();
        }
    }
}