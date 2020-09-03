using MediatR;

namespace Misty.Commands.Users
{
    public class BanUser : IRequest
    {
        public string Username { get; set; }
    }
}