using System;

namespace Misty.Domain.Entities
{
    public class User : Visitor
    {
        public int Id { get; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public bool IsBanned { get; private set; }

        public User( string username, string password, string email, string ipAddress) : base(ipAddress)
        {
            var random = new Random();
            Id = random.Next(int.MaxValue);
            Username = username;
            Password = password;
            Email = email;
            IsBanned = false;
        }
    }
}