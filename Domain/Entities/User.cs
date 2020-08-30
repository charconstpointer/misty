using System;

namespace Misty.Domain.Entities
{
    public class User : Visitor
    {
        public User(string username, string password, string email, string ipAddress) : base(ipAddress)
        {
            var random = new Random();
            Id = random.Next(int.MaxValue);
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
        public string Password { get; }
        public string Email { get; }
        public bool IsBanned { get; }
    }
}