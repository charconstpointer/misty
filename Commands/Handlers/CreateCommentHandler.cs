using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Misty.Commands.Comments;
using Misty.Domain.Entities;

namespace Misty.Commands.Handlers
{
    public class CreateCommentHandler : IRequestHandler<CreateComment>
    {
        private readonly ICollection<Article> _articles;

        public CreateCommentHandler(ICollection<Article> articles)
        {
            _articles = articles;
        }

        public Task<Unit> Handle(CreateComment request, CancellationToken cancellationToken)
        {
            var article = _articles.SingleOrDefault(a => a.Id == request.ArticleId);
            if (article == null)
            {
                throw new ApplicationException($"Article with id : {request.ArticleId} could not be found");
            }

            var comment = new Comment(request.Content);
            article.AddComment(comment);
            return Unit.Task;
        }
    }
}