using MediatR;

namespace Misty.Commands.Ads
{
    public class CreateNewAd : IRequest
    {
        public string Path { get; set; }
        public decimal Price { get; set; }
    }
}