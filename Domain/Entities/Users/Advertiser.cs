using System.ComponentModel.DataAnnotations.Schema;

namespace Misty.Domain.Entities.Users
{
    public class Advertiser : RegisteredUser
    {
        private Advertiser()
        {
        }

        public Advertiser(string username, string password, string email, string ipAddress) : base(username, password,
            email, ipAddress)
        {
        }

        public bool IsVerified { get; private set; }

        public void Verify(Moderator moderator)
        {
            if (!moderator.IsBanned)
            {
                IsVerified = true;
            }
        }
    }
}