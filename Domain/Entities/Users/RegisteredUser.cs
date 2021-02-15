using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Misty.Domain.Entities.Content;
using Misty.Domain.Enums;

namespace Misty.Domain.Entities.Users
{
    public class RegisteredUser : Visitor
    {
        internal RegisteredUser()
        {
        }

        protected RegisteredUser(string username, string password, string email, string ipAddress) : base(ipAddress)
        {
            Username = username;
            Password = password;
            Email = email;
            IsBanned = false;
        }

        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public string Email { get; protected set; }
        public bool IsBanned { get; private set; }
        private readonly ICollection<Comment> _comments = new List<Comment>();
        public ICollection<Comment> Comments => _comments.ToImmutableList();

        public static RegisteredUser CreateAccount(string username, string password, string email, string ipAddress,
            UserType userType = UserType.Creator)
        {
            ValidateParameters();

            RegisteredUser user = userType switch
            {
                UserType.Moderator => new Moderator(username, password, email, ipAddress),
                UserType.Creator => new Creator(username, password, email, ipAddress),
                UserType.Advertiser => new Advertiser(username, password, email, ipAddress),
                _ => throw new ArgumentOutOfRangeException(nameof(userType), userType, null)
            };
            return user;

            void ValidateParameters()
            {
                if (username == null) throw new ArgumentNullException(nameof(username));
                if (password == null) throw new ArgumentNullException(nameof(password));
                if (email == null) throw new ArgumentNullException(nameof(email));
                if (ipAddress == null) throw new ArgumentNullException(nameof(ipAddress));
            }
        }

        public void AddComment(Comment comment)
        {
            if (comment == null) throw new ArgumentNullException(nameof(comment));
            if (_comments.Contains(comment)) return;

            _comments.Add(comment);
            comment.SetAuthor(this);
        }

        public void Ban(Moderator moderator)
        {
            if (IsBanned) throw new ApplicationException("User is already banned");
            if (moderator == null) throw new ArgumentNullException(nameof(moderator));
            IsBanned = true;
        }
    }
}