using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Misty.Commands.Users;

namespace Misty.Commands.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUser, string>
    {
        
        public LoginUserHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }
        public async Task<string> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            var token = Token(request.Username);
            return token;

            string Token(string username)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = "fennec",
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(1000),
                    SigningCredentials =
                        new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Key"])),
                            SecurityAlgorithms.HmacSha256Signature)
                };
                var t = tokenHandler.CreateToken(tokenDescriptor);
                var wt = tokenHandler.WriteToken(t);
                return wt;
            }
        }
    }
}