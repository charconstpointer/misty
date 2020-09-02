using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Commands.Articles;
using Misty.Persistence;

namespace Misty.Commands.Handlers
{
    public class UpdateArticleHandler : IRequestHandler<UpdateArticle>
    {
        private readonly MistyContext _context;

        public UpdateArticleHandler(MistyContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateArticle request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}