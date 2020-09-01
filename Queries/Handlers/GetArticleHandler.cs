using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities;
using Misty.Domain.Entities.Content;
using Misty.Domain.Repositories;
using Misty.Persistence;

namespace Misty.Queries.Handlers
{
    public class GetArticleHandler : IRequestHandler<GetArticle, Article>
    {
        private readonly MistyContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetArticleHandler(MistyContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<Article> Handle(GetArticle request, CancellationToken cancellationToken)
        {
            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var article = await _context.Articles
                .Include(a => a.Ads)
                .Include(a => a.Comments)
                .Include(a => a.Category)
                .SingleOrDefaultAsync(a => a.Id == request.ArticleId, cancellationToken: cancellationToken);
            return article;
        }
    }
}