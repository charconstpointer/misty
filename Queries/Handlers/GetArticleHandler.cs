using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Misty.Commands;
using Misty.Domain.Entities;
using Misty.Domain.Entities.Users;
using Misty.Dto;
using Misty.Extensions.Mappings;
using Misty.Persistence;
using Misty.Queries.Articles;

namespace Misty.Queries.Handlers
{
    public class GetArticleHandler : IRequestHandler<GetArticle, ArticleDto>
    {
        private readonly MistyContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserAccessor _userAccessor;

        public GetArticleHandler(IUserAccessor userAccessor, MistyContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _userAccessor = userAccessor;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ArticleDto> Handle(GetArticle request, CancellationToken cancellationToken)
        {
            var article = await _context.Articles
                .Include(a => a.Ads)
                .Include(a => a.Comments)
                .Include(a => a.Category)
                .Include(a => a.ContentVisitors)
                .SingleOrDefaultAsync(a => a.Id == request.ArticleId, cancellationToken);
            
            var username = await _userAccessor.GetUsername();
            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;

            if (string.IsNullOrEmpty(username))
            {
                var visitor = new Visitor(ipAddress.ToString());
                var visit = new ContentVisitor(article, visitor);
                visitor.AddVisit(visit);
                await _context.Visitors.AddAsync(visitor, cancellationToken);
            }
            else
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Username.ToLower() == username,
                    cancellationToken);
                if (user == null) throw new ApplicationException($"Could not find such user {username}");

                var visit = new ContentVisitor(article, user);
                user.AddVisit(visit);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return article.AsDto();
        }
    }
}