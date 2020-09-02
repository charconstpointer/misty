using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Misty.Dto;
using Misty.Extensions.Mappings;
using Misty.Persistence;

namespace Misty.Queries.Handlers
{
    public class GetArticleHandler : IRequestHandler<GetArticle, ArticleDto>
    {
        private readonly MistyContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetArticleHandler(MistyContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<ArticleDto> Handle(GetArticle request, CancellationToken cancellationToken)
        {
            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var article = await _context.Articles
                .Include(a => a.Ads)
                .Include(a => a.Comments)
                .Include(a => a.Category)
                .SingleOrDefaultAsync(a => a.Id == request.ArticleId, cancellationToken);
            return article.AsDto();
        }
    }
}