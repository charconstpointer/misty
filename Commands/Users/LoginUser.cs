using MediatR;

namespace Misty.Commands.Users
{
    public class LoginUser : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}