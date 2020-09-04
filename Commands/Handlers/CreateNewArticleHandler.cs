using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Misty.Commands.Articles;
using Misty.Domain.Entities.Content;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class CreateNewArticleHandler : IRequestHandler<CreateNewArticle>
    {
        private readonly MistyContext _context;
        private readonly IUserAccessor _userAccessor;

        public CreateNewArticleHandler(MistyContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Unit> Handle(CreateNewArticle request, CancellationToken cancellationToken)
        {
            var username = await _userAccessor.GetUsername();

            var creator = await _context.Creators.SingleOrDefaultAsync(u => u.Username.ToLower() == username.ToLower(),
                cancellationToken);
            if (creator == null) throw new ApplicationException("No such creator");

            var category = await _context.Categories.SingleOrDefaultAsync(c => c.Id == request.CategoryId,
                cancellationToken);
            var article = new Article(request.Title, request.Description, request.Body, creator, category);
            await _context.Articles.AddAsync(article, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}