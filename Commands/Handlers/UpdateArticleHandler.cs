using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Commands.Articles;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class UpdateArticleHandler : IRequestHandler<UpdateArticle>
    {
        private readonly MistyContext _context;

        public UpdateArticleHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateArticle request, CancellationToken cancellationToken)
        {
            var article = await _context.Articles.Include(a => a.Ads)
                .SingleOrDefaultAsync(a => a.Id == request.ArticleId, cancellationToken: cancellationToken);
            var ads = await _context.Ads.Where(a => request.AdIds.Contains(a.Id))
                .ToListAsync(cancellationToken: cancellationToken);
            if (article == null)
            {
                throw new ApplicationException($"Cannot find such article {request.ArticleId}");
            }

            article.AddAds(ads);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}