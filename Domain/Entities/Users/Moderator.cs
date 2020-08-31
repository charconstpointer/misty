namespace Misty.Domain.Entities.Users
{
    public class Moderator : RegisteredUser
    {
        public Moderator(string username, string password, string email, string ipAddress) : base(username, password,
            email, ipAddress)
        {
        }

        public Category ModeratedCategory { get; private set; }

        public void Verify(Advertiser advertiser)
        {
            advertiser.Verify(this);
        }
    }
}