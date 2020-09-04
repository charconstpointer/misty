using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Misty.Commands.Ads;
using Misty.Domain.Entities.Content;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class CreateNewAdHandler : IRequestHandler<CreateNewAd>
    {
        private readonly MistyContext _context;
        private readonly IUserAccessor _userAccessor;

        public CreateNewAdHandler(MistyContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Unit> Handle(CreateNewAd request, CancellationToken cancellationToken)
        {
            var username = await _userAccessor.GetUsername();
            var advertiser = await _context.Advertisers.SingleOrDefaultAsync(a => a.Username.ToLower() == username.ToLower(),
                cancellationToken);
            var ad = Ad.Create(request.Path, request.Price, advertiser);
            await _context.AddAsync(ad, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}