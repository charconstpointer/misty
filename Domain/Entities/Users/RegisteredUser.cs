using System;
using System.Collections.Generic;
using Misty.Domain.Entities.Content;
using Misty.Domain.Enums;

namespace Misty.Domain.Entities.Users
{
    public class RegisteredUser : Visitor
    {
        private readonly ICollection<Comment> _comments = new List<Comment>();

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

        public string Username { get; }
        public string Password { get; }
        public string Email { get; }
        public bool IsBanned { get; private set; }


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

        public void Ban(Moderator moderator)
        {
            if (IsBanned) throw new ApplicationException("User is already banned");
            if (moderator == null) throw new ArgumentNullException(nameof(moderator));
            IsBanned = true;
        }
    }
}