using MediatR;

namespace Misty.Commands.Comments
{
    public class CreateComment : IRequest
    {
        public int ArticleId { get; set; }
        public string Content { get; set; }
    }
}