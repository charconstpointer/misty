using System;
using System.Collections.Generic;
using System.Linq;
using Misty.Domain.Entities.Content;

namespace Misty.Domain.Entities.Users
{
    public class Advertiser : RegisteredUser
    {
        public Advertiser(string username, string password, string email, string ipAddress) : base(username, password,
            email, ipAddress)
        {
        }

        private Advertiser()
        {
        }

        public bool IsVerified { get; private set; }
        private readonly ICollection<Ad> _ads = new HashSet<Ad>();
        public IEnumerable<Ad> Ads => _ads.ToList();

        public void AddAd(Ad ad)
        {
            if (ad == null) throw new ArgumentNullException(nameof(ad));
            if (_ads.Contains(ad))
            {
                return;
            }

            _ads.Add(ad);
        }

        public void Verify(Moderator moderator)
        {
            if (moderator == null) throw new ArgumentNullException(nameof(moderator));

            if (!moderator.IsBanned) IsVerified = true;
        }
    }
}