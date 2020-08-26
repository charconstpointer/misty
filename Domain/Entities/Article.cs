using System;

namespace Misty.Domain.Entities
{
    public class Article
    {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }

        private Article(string description, string title)
        {
            var random = new Random();
            Id = random.Next(int.MaxValue);
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