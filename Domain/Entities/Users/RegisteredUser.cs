namespace Misty.Domain.Entities.Users
{
    public class RegisteredUser : Visitor
    {
        public RegisteredUser(string username, string password, string email, string ipAddress) : base(ipAddress)
        {
            Username = username;
            Password = password;
            Email = email;
            IsBanned = false;
        }

        internal RegisteredUser()
        {
        }

        public int Id { get; }
        public string Username { get; }
        public string Password { get; }
        public string Email { get; }
        public bool IsBanned { get; }
    }
}