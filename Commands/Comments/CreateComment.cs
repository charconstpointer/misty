using MediatR;

namespace Misty.Commands.Comments
{
    public class CreateComment : IRequest
    {
        public string Content { get; set; }
    }
}