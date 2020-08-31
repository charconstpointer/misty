using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities;
using Misty.Persistence;
using Misty.Queries.Ads;

namespace Misty.Queries.Handlers
{
    public class GetAdHandler : IRequestHandler<GetAd, Ad>
    {
        private readonly MistyContext _context;

        public GetAdHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<Ad> Handle(GetAd request, CancellationToken cancellationToken)
        {
            var ad = await _context.Ads.SingleOrDefaultAsync(a => a.Id == request.AdId,
                cancellationToken: cancellationToken);
            return ad;
        }
    }
}