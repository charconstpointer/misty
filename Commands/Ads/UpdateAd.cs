using MediatR;

namespace Misty.Commands.Ads
{
    public class UpdateAd : IRequest
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public decimal Price { get; set; }
    }
}