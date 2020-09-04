using Misty.Domain.Entities.Users;

namespace Misty.Domain.Entities.Content
{
    public class Article : Content
    {
        private Article()
        {
        }

        public Article(string title, string description, string body, Creator creator, Category category = null) : base(
            title,
            description, creator, category)
        {
            Body = body;
        }

        public string Body { get; private set; }
    }
}