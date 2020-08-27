using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Commands.Users;

namespace Misty.Commands.Handlers
{
    public class CreateNewUserHandler : IRequestHandler<CreateNewUser>
    {
        public async Task<Unit> Handle(CreateNewUser request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}