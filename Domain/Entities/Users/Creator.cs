using System;
using System.Collections.Generic;
using System.Linq;

namespace Misty.Domain.Entities.Users
{
    public class Creator : RegisteredUser
    {
        private readonly ICollection<Content.Content> _contents;

        public Creator(string username, string password, string email, string ipAddress) : base(username, password,
            email, ipAddress)
        {
            _contents = new HashSet<Content.Content>();
        }

        public decimal Balance { get; private set; }
        public IEnumerable<Content.Content> Contents => _contents.ToList();

        public void AddContent(Content.Content content)
        {
            if (content.Creator == this) _contents.Add(content);

            throw new ApplicationException("You are not an owner of this content");
        }
    }
}