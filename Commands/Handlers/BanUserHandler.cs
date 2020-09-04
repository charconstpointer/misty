using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Commands.Users;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class BanUserHandler : IRequestHandler<BanUser>
    {
        private readonly MistyContext _context;
        private readonly IUserAccessor _userAccessor;

        public BanUserHandler(MistyContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Unit> Handle(BanUser request, CancellationToken cancellationToken)
        {
            var username = await _userAccessor.GetUsername();
            var moderator = await _context.Moderators.SingleAsync(m => m.Username == username, cancellationToken);
            var user = await _context.Users.SingleAsync(u => u.Username == request.Username, cancellationToken);
            moderator.BanUser(user);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}