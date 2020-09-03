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
            // if (!_httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out var bearer))
            //     throw new ApplicationException();

            var username = await _userAccessor.GetUsername();

            var creator = await _context.Creators.SingleOrDefaultAsync(u => u.Username.ToLower() == username.ToLower(),
                cancellationToken);
            if (creator == null) throw new ApplicationException("No such creator");

            var cats = await _context.Categories.ToListAsync(cancellationToken);
            var category = await _context.Categories.SingleOrDefaultAsync(c => c.Id == request.CategoryId,
                cancellationToken);
            var article = new Article(request.Title, request.Description, request.Body, creator, category);
            await _context.Articles.AddAsync(article, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        private static string GetUsername(StringValues bearer)
        {
            var s = bearer.ToString();
            var token = s.AsSpan().Slice("Bearer ".Length).ToString();
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            return tokenS?.Claims.Single(c => c.Type == "unique_name").Value;
        }
    }
}