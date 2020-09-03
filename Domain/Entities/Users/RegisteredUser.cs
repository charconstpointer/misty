using System;
using Misty.Domain.Enums;

namespace Misty.Domain.Entities.Users
{
    public class RegisteredUser : Visitor
    {
        protected RegisteredUser(string username, string password, string email, string ipAddress) : base(ipAddress)
        {
            Username = username;
            Password = password;
            Email = email;
            IsBanned = false;
        }


        internal RegisteredUser()
        {
        }

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

        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public bool IsBanned { get; private set; }
    }
}