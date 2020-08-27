using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Commands.Ads;

namespace Misty.Commands.Handlers
{
    public class UpdateAdHandler : IRequestHandler<UpdateAd>
    {
        public async Task<Unit> Handle(UpdateAd request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}