using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities.Users;
using Misty.Persistence;
using Misty.Queries.Users;

namespace Misty.Queries.Handlers
{
    public class GetRegisteredUsersHandler : IRequestHandler<GetRegisteredUsers, IEnumerable<RegisteredUser>>
    {
        private readonly MistyContext _context;

        public GetRegisteredUsersHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegisteredUser>> Handle(GetRegisteredUsers request,
            CancellationToken cancellationToken)
        {
            var users = await _context.Users.ToListAsync(cancellationToken);
            return users;
        }
    }
}