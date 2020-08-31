using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Commands.Ads;
using Misty.Domain.Entities;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class CreateNewAdHandler : IRequestHandler<CreateNewAd>
    {
        private readonly MistyContext _context;

        public CreateNewAdHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateNewAd request, CancellationToken cancellationToken)
        {
            var ad = new Ad(request.Path, request.Price, null);
            await _context.AddAsync(ad, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}