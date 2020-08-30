using System;

namespace Misty.Domain.Entities
{
    public class User : Visitor
    {
        public User(string username, string password, string email, string ipAddress) : base(ipAddress)
        {
            Username = username;
            Password = password;
            Email = email;
            IsBanned = false;
        }

        private User()
        {
        }

        public int Id { get; }
        public string Username { get; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public bool IsBanned { get; private set; }
    }
}