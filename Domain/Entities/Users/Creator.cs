using System;
using System.Collections.Generic;
using System.Linq;
using Misty.Domain.Entities.Content;

namespace Misty.Domain.Entities.Users
{
    public class Creator : RegisteredUser
    {
        private readonly ICollection<Comment> _comments = new List<Comment>();
        private readonly ICollection<Content.Content> _contents = new HashSet<Content.Content>();

        public Creator(string username, string password, string email, string ipAddress) : base(username, password,
            email, ipAddress)
        {
        }

        private Creator()
        {
        }

        public decimal Balance { get; private set; }
        public IEnumerable<Content.Content> Contents => _contents.ToList();

        public void AddComment(Comment comment)
        {
            if (comment == null) throw new ArgumentNullException(nameof(comment));
            if (_comments.Contains(comment)) return;

            _comments.Add(comment);
            comment.SetAuthor(this);
        }

        public void AddContent(Content.Content content)
        {
            if (content.Creator != this) throw new ApplicationException("You are not an owner of this content");
            _contents.Add(content);
        }
    }
}