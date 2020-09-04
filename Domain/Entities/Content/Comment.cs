using System;
using Misty.Domain.Entities.Users;

namespace Misty.Domain.Entities.Content
{
    //TODO Comment composition
    //TODO Ad Association
    public class Comment
    {
        private Comment()
        {
        }

        public Comment(string content, Creator author)
        {
            if (content == null) throw new ArgumentNullException(nameof(content));
            if (author == null) throw new ArgumentNullException(nameof(author));
            var snapshot = DateTime.UtcNow;
            Content = content;
            CreatedAt = snapshot;
            LastChangedAt = snapshot;
            Author = author;
            author.AddComment(this);
        }

        public int Id { get; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastChangedAt { get; private set; }
        public Creator Author { get; private set; }
        public Content Article { get; private set; }

        public void SetAuthor(Creator author)
        {
            if (Author != null) return;
            Author = author;
            author.AddComment(this);
        }

        public void Edit(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new ArgumentException("Value cannot be null or empty.", nameof(content));

            Content = content;
            LastChangedAt = DateTime.UtcNow;
        }

        public void SetContent(Content content)
        {
            if (content == null) throw new ArgumentNullException(nameof(content));
            if (Article != null) return;

            Article = content;
            content.AddComment(this);
        }

        public void Delete()
        {
            if (Content == null)
            {
                return;
            }

            Article.RemoveComment(this);
            Article = null;
            Author = null;
        }
    }
}