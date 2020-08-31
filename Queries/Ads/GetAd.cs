using MediatR;
using Misty.Domain.Entities;

namespace Misty.Queries.Ads
{
    public class GetAd : IRequest<Ad>
    {
        public int AdId { get; set; }
    }
}