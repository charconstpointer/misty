using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Commands.Ads;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class UpdateAdHandler : IRequestHandler<UpdateAd>
    {
        private readonly MistyContext _context;
        private readonly IUserAccessor _userAccessor;

        public UpdateAdHandler(MistyContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Unit> Handle(UpdateAd request, CancellationToken cancellationToken)
        {
            var username = await _userAccessor.GetUsername();
            var advertiser = await _context.Advertisers.SingleAsync(a => a.Username.ToLower() == username.ToLower(),
                cancellationToken: cancellationToken);
            var ad = await _context.Ads.SingleOrDefaultAsync(a => a.Id == request.Id,
                cancellationToken: cancellationToken);
            if (ad == null)
            {
                throw new ApplicationException("Could not find an ad with given id");
            }

            ad.Edit(advertiser, request.Path, request.Price);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}