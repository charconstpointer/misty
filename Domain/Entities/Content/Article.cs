using Misty.Domain.Entities.Users;

namespace Misty.Domain.Entities.Content
{
    public class Article : Content
    {
        public Article(string title, string description, Creator creator, Category category = null) : base(title,
            description, creator, category)
        {
        }

        private Article()
        {
        }

        public string Body { get; private set; }
    }
}