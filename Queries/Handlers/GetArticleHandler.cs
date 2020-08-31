using System.Threading;
using System.Threading.Tasks;
using MediatR;
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

        public GetArticleHandler(MistyContext context)
        {
            _context = context;
        }


        public async Task<Article> Handle(GetArticle request, CancellationToken cancellationToken)
        {
            var article = await _context.Articles
                .Include(a => a.Ads)
                .Include(a => a.Comments)
                .Include(a => a.Category)
                .SingleOrDefaultAsync(a => a.Id == request.ArticleId, cancellationToken: cancellationToken);
            return article;
        }
    }
}