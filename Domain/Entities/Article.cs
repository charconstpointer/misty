using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Misty.Domain.Entities
{
    public class Article
    {
        private readonly ISet<Ad> _ads;
        private readonly ISet<Comment> _comments;

        private Article(string description, string title)
        {
            Description = description;
            Title = title;
            _ads = new HashSet<Ad>();
            _comments = new HashSet<Comment>();
        }

        private Article()
        {
        }

        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public Category Category { get; private set; }
        public IEnumerable<Comment> Comments => _comments.ToImmutableList();
        public IEnumerable<Ad> Ads => _ads.ToImmutableList();

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