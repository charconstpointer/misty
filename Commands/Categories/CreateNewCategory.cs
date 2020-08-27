using MediatR;

namespace Misty.Commands.Categories
{
    public class CreateNewCategory : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}