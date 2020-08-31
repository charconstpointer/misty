using MediatR;

namespace Misty.Commands.Categories
{
    public class DeleteCategory : IRequest
    {
        public int CategoryId { get; set; }
    }
}