using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Commands.Users;
using Misty.Domain.Entities;
using Misty.Domain.Repositories;

namespace Misty.Commands.Handlers
{
    public class CreateNewUserHandler : IRequestHandler<CreateNewUser>
    {
        private readonly IUsersRepository _usersRepository;

        public CreateNewUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Unit> Handle(CreateNewUser request, CancellationToken cancellationToken)
        {
            var user = new RegisteredUser(request.Username, request.Password, request.Email, "");
            await _usersRepository.Save(user);
            return Unit.Value;
        }
    }
}