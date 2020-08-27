using MediatR;

namespace Misty.Commands.Articles
{
    public class CreateNewArticle : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}