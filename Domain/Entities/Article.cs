using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Misty.Domain.Entities
{
    public class Article
    {
        private readonly ISet<Comment> _comments;

        private Article(string description, string title)
        {
            var random = new Random();
            Id = random.Next(int.MaxValue);
            Description = description;
            Title = title;
            _comments = new HashSet<Comment>();
        }

        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public IReadOnlyCollection<Comment> Comments => _comments.ToImmutableList();

        public void AddComment(Comment comment)
        {
            if (comment == null) throw new ApplicationException("Comment cannot be null");

            _comments.Add(comment);
        }

        public static Article Create(string title, string description)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException($"'{nameof(title)}' cannot be null or empty", nameof(title));

            if (string.IsNullOrEmpty(description))
                throw new ArgumentException($"'{nameof(description)}' cannot be null or empty", nameof(description));

            var article = new Article(title, description);
            return article;
        }
    }
}