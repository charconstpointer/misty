using System.Collections.Generic;
using System.Linq;
using Misty.Domain.Entities.Content;
using Misty.Dto;

namespace Misty.Extensions.Mappings
{
    public static class CommentExtensions
    {
        public static CommentDto AsDto(this Comment comment)
            => new CommentDto
            {
                Author = comment.Author?.Username,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                LastChangedAt = comment.LastChangedAt
            };

        public static IEnumerable<CommentDto> AsDto(this IEnumerable<Comment> comments)
            => comments.Select(AsDto);
    }
}