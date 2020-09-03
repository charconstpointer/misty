using System.Collections.Generic;
using System.Linq;
using Misty.Domain.Entities.Content;
using Misty.Dto;

namespace Misty.Extensions.Mappings
{
    public static class ArticleExtensions
    {
        public static ArticleDto AsDto(this Article article)
        {
            return new ArticleDto
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Description,
                Body = article.Body,
                Comments = article.Comments?.Select(c => c.Content),
                Tags = Enumerable.Empty<string>(),
                ViewCount = article.ContentVisitors.Select(cv => cv.Visitor).Count(),
                Ads = article.Ads?.Select(a => a.Path),
                Ad = article.GetRandomAd()?.Path,
                Creator = article.Creator?.Username,
                CreatedAt = article.CreatedAt
            };
        }

        public static IEnumerable<ArticleDto> AsDto(this IEnumerable<Article> articles)
        {
            return articles.Select(AsDto);
        }
    }
}