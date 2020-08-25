using System;

namespace Misty.Domain.Entites
{
    public class Article
    {
        public Guid Id { get; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        private Article(string description, string title)
        {
            Id = Guid.NewGuid();
            Description = description;
            Title = title;
        }

        public static Article Create(string title, string description)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or empty", nameof(title));
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException($"'{nameof(description)}' cannot be null or empty", nameof(description));
            }

            var article = new Article(title, description);
            return article;
        }
    }
}