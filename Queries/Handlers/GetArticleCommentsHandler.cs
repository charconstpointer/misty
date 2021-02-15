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
    public class GetArticleCommentsHandler : IRequestHandler<GetArticleComments, IEnumerable<CommentDto>>
    {
        private readonly MistyContext _context;

        public GetArticleCommentsHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CommentDto>> Handle(GetArticleComments request,
            CancellationToken cancellationToken)
        {
            var articles = await _context.Articles
                .Include(a => a.Comments)
                .ThenInclude(c=>c.Author)
                .Include(a => a.Creator)
                .ToListAsync(cancellationToken: cancellationToken);

            var article = articles.FirstOrDefault(a=>a.Id == request.ArticleId);
            return article?.Comments.AsDto();
        }
    }
}