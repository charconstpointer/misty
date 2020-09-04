using System.Collections.Generic;
using MediatR;
using Misty.Domain.Entities.Content;
using Misty.Dto;

namespace Misty.Queries.Articles
{
    public class GetArticleComments : IRequest<IEnumerable<CommentDto>>
    {
        public int ArticleId { get; set; }
    }
}