using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Dto;
using Misty.Extensions.Mappings;
using Misty.Persistence;

namespace Misty.Queries.Articles
{
    public class GetArticlesByCategory : IRequest<IEnumerable<ArticleDto>>
    {
        public GetArticlesByCategory(int categoryId)
        {
            CategoryId = categoryId;
        }

        public int CategoryId { get; set; }
    }
    
    
    public class GetArticlesByCategoryHandler : IRequestHandler<GetArticlesByCategory, IEnumerable<ArticleDto>>
    {
        private readonly MistyContext _context;

        public GetArticlesByCategoryHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ArticleDto>> Handle(GetArticlesByCategory request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .Include(c=>c.Contents)
                .ThenInclude(c=>c.Ads)
                .Include(c=>c.Contents)
                .ThenInclude(c=>c.Comments)
                .Include(c=>c.Contents)
                .ThenInclude(c=>c.Creator).Include(c=>c.Contents)
                .ThenInclude(c=>c.ContentVisitors)
                .FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken: cancellationToken);
            return category.Contents.AsDto();
        }
    }
}