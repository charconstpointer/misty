using System.Collections.Generic;
using MediatR;
using Misty.Domain.Entities.Content;

namespace Misty.Queries.Ads
{
    public class GetAds : IRequest<IEnumerable<Ad>>
    {
        public IEnumerable<Ad> Ads { get; set; }
    }
}