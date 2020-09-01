using System;

namespace Misty.Domain.Entities.Content
{
    public class Comment
    {
        public Comment(string content)
        {
            //TODO validate content
            var snapshot = DateTime.UtcNow;
            Content = content;
            CreatedAt = snapshot;
            LastChangedAt = snapshot;
        }

        private Comment()
        {
        }

        public int Id { get; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastChangedAt { get; private set; }

        public void Edit(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new ArgumentException("Value cannot be null or empty.", nameof(content));

            Content = content;
            LastChangedAt = DateTime.UtcNow;
        }
    }
}