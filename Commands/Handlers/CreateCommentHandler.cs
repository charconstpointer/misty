using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Commands.Comments;
using Misty.Domain.Entities.Content;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class CreateCommentHandler : IRequestHandler<CreateComment>
    {
        private readonly MistyContext _context;
        private readonly IUserAccessor _userAccessor;

        public CreateCommentHandler(MistyContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Unit> Handle(CreateComment request, CancellationToken cancellationToken)
        {
            var username = await _userAccessor.GetUsername();
            var creator = await _context.Creators.SingleOrDefaultAsync(c => c.Username.ToLower() == username.ToLower(),
                cancellationToken);
            if (creator == null)
            {
                throw new ApplicationException($"Could not find requested creator {username}");
            }

            var article = await _context.Articles.SingleOrDefaultAsync(a => a.Id == request.ArticleId,
                cancellationToken);
            if (article == null)
                throw new ApplicationException($"Article with id : {request.ArticleId} could not be found");

            var comment = new Comment(request.Content, creator);
            article.AddComment(comment);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}