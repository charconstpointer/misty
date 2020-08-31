using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misty.Domain.Entities;
using Misty.Domain.Entities.Content;

namespace Misty.Persistence.Configurations
{
    public class ArticleEntityConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.Category);
            builder.HasMany(a => a.Comments);
            builder.HasMany(a => a.Ads);
        }
    }
}