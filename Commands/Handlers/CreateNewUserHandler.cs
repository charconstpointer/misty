using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Misty.Commands.Users;
using Misty.Domain.Entities;
using Misty.Domain.Entities.Users;
using Misty.Domain.Enums;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class CreateNewUserHandler : IRequestHandler<CreateNewUser>
    {
        private readonly MistyContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateNewUserHandler(MistyContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
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

            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var user = request.UserType switch
            {
                UserType.Advertiser => new RegisteredUser(request.Username, request.Password, request.Email, ipAddress),
                UserType.Creator => new Creator(request.Username, request.Password, request.Email, ipAddress),
                UserType.Moderator => new Moderator(request.Username, request.Password, request.Email, ipAddress),
                _ => throw new ArgumentOutOfRangeException()
            };

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}