namespace Misty.Domain.Entities.Users
{
    public class Creator : RegisteredUser
    {
        public Creator(string username, string password, string email, string ipAddress) : base(username, password,
            email, ipAddress)
        {
        }

        public decimal Balance { get; private set; }

        public void Withdraw(decimal amount)
        {
            //TODO 
        }
    }
}