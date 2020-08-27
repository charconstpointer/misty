using MediatR;

namespace Misty.Commands.Users
{
    public class CreateNewUser : IRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}