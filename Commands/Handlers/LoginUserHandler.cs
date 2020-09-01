using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Misty.Commands.Users;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUser, string>
    {
        private readonly MistyContext _context;

        public LoginUserHandler(IConfiguration configuration, MistyContext context)
        {
            Configuration = configuration;
            _context = context;
        }

        public IConfiguration Configuration { get; }

        public async Task<string> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.ToListAsync(cancellationToken);
            var user = users.SingleOrDefault(u => u.Username.ToLower() == request.Username.ToLower());
            if (user == null) throw new ApplicationException("User does not exists");

            if (user.Password != request.Password) throw new ApplicationException("Incorrect password");

            var token = CreateToken(user.Username);
            return token;
        }

        private Password HashPassword(int size, string password, string salt = null)
        {
            var saltBytes = new byte[size];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            salt ??= Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            var hashSalt = new Password {Hash = hashPassword, Salt = salt};
            return hashSalt;
        }

        private string CreateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "misty",
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["key"])),
                        SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var wt = tokenHandler.WriteToken(token);
            return wt;
        }

        public class Password
        {
            public string Hash { get; set; }
            public string Salt { get; set; }
        }
    }
}