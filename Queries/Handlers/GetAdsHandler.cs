using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities;
using Misty.Persistence;
using Misty.Queries.Ads;

namespace Misty.Queries.Handlers
{
    public class GetAdsHandler : IRequestHandler<GetAds, IEnumerable<Ad>>
    {
        private readonly MistyContext _context;

        public GetAdsHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ad>> Handle(GetAds request, CancellationToken cancellationToken)
        {
            var ads = await _context.Ads.ToListAsync(cancellationToken: cancellationToken);
            return ads;
        }
    }
}