using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Commands.Comments;
using Misty.Domain.Entities;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class CreateCommentHandler : IRequestHandler<CreateComment>
    {
        private readonly MistyContext _context;

        public CreateCommentHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateComment request, CancellationToken cancellationToken)
        {
            var article = await _context.Articles.SingleOrDefaultAsync(a => a.Id == request.ArticleId,
                cancellationToken: cancellationToken);
            if (article == null)
                throw new ApplicationException($"Article with id : {request.ArticleId} could not be found");

            var comment = new Comment(request.Content);
            article.AddComment(comment);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}