using System;

namespace Misty.Domain.Entities
{
    public class Comment
    {
        public string Content { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime LastChangedAt { get; private set; }

        public Comment(string content)
        {
            var snapshot = DateTime.UtcNow;
            Content = content;
            CreatedAt = snapshot;
            LastChangedAt = snapshot;
        }

        public void Edit(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(content));
            }

            Content = content;
            LastChangedAt = DateTime.UtcNow;
        }
    }
}