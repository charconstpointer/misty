using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Misty.Commands.Users;
using Misty.Domain.Entities;
using Misty.Domain.Enums;
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
            if (string.IsNullOrEmpty(request.Username))
            {
                throw new ApplicationException("Username cannot be null");
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                throw new ApplicationException("Password cannot be null");
            }

            if (string.IsNullOrEmpty(request.Email))
            {
                throw new ApplicationException("Email cannot be null");
            }

            var user = request.UserType switch
            {
                UserType.Advertiser => new RegisteredUser(request.Username, request.Password, request.Email, ""),
                UserType.Creator => new RegisteredUser(request.Username, request.Password, request.Email, ""),
                UserType.Moderator => new RegisteredUser(request.Username, request.Password, request.Email, ""),
                _ => throw new ArgumentOutOfRangeException()
            };

            await _usersRepository.Save(user);
            return Unit.Value;
        }
        
    }
}