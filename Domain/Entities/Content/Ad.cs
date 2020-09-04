using System;
using Misty.Domain.Entities.Users;

namespace Misty.Domain.Entities.Content
{
    //TODO GetAllUserAds()
    public class Ad
    {
        private Ad()
        {
        }

        private Ad(string path, decimal price, Advertiser advertiser)
        {
            //TODO validate if valid url
            Path = path;
            PricePerView = price;
            CreatedAt = DateTime.UtcNow;
            Advertiser = advertiser;
        }

        public int Id { get; }
        public string Path { get; private set; }
        public decimal PricePerView { get; private set; }
        public DateTime CreatedAt { get; private set;}
        public Advertiser Advertiser { get; private set;}

        public static Ad Create(string path, decimal price, Advertiser advertiser)
        {
            if (advertiser == null) throw new ArgumentNullException(nameof(advertiser));
            ValidateAd(path, price);
            var ad = new Ad(path, price, advertiser);
            advertiser.AddAd(ad);
            return ad;
        }

        private static void ValidateAd(string path, decimal price)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
            if (price < 0) throw new ArgumentNullException(nameof(price));
        }

        public void Edit(Advertiser advertiser, string path = "", decimal price = -1)
        {
            if (advertiser != Advertiser) throw new ApplicationException("You can only edit ads you own");
            ValidateAd(path, price);
            PricePerView = price;
            Path = path;
        }
    }
}