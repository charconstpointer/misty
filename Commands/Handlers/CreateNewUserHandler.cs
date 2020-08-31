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
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class CreateNewUserHandler : IRequestHandler<CreateNewUser>
    {
        private readonly MistyContext _context;

        public CreateNewUserHandler(MistyContext context)
        {
            _context = context;
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

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}