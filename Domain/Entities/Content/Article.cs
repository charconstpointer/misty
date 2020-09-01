namespace Misty.Domain.Entities.Content
{
    public class Article : Content
    {
        public Article(string title, string description, Category category = null) : base(title, description, category)
        {
        }

        private Article()
        {
        }

        public string Body { get; private set; }
    }
}