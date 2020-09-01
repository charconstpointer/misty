using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Commands.Articles;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class DeleteArticleHandler : IRequestHandler<DeleteArticle>
    {
        private readonly MistyContext _context;

        public DeleteArticleHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteArticle request, CancellationToken cancellationToken)
        {
            var article = await _context.Articles.SingleOrDefaultAsync(a => a.Id == request.ArticleId,
                cancellationToken: cancellationToken);
            if (article == null)
            {
                throw new ApplicationException("Article not found");
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}