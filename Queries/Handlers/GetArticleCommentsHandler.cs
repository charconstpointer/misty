using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities;
using Misty.Persistence;

namespace Misty.Queries.Handlers
{
    public class GetArticleCommentsHandler : IRequestHandler<GetArticleComments, IEnumerable<Comment>>
    {
        private readonly MistyContext _context;

        public GetArticleCommentsHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> Handle(GetArticleComments request, CancellationToken cancellationToken)
        {
            var article = await _context.Articles.SingleOrDefaultAsync(a => a.Id == request.ArticleId,
                cancellationToken: cancellationToken);
            var comments = article.Comments;
            return comments;
        }
    }
}