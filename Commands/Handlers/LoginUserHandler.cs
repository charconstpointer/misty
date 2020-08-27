using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Commands.Users;

namespace Misty.Commands.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUser, string>
    {
        public async Task<string> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            return "token";
        }
    }
}