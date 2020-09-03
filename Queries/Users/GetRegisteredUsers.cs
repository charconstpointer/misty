using System.Collections.Generic;
using MediatR;
using Misty.Domain.Entities.Users;

namespace Misty.Queries.Users
{
    public class GetRegisteredUsers : IRequest<IEnumerable<RegisteredUser>>
    {
    }
}