using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misty.Domain.Entities.Content;

namespace Misty.Persistence.Configurations
{
    // public class ArticleEntityConfiguration : IEntityTypeConfiguration<Article>
    // {
    //     public void Configure(EntityTypeBuilder<Article> builder)
    //     {
    //         builder.HasOne(a => a.Category);
    //         builder.HasMany(a => a.Comments);
    //         builder.HasMany(a => a.Ads);
    //     }
    // }

    public class ContentEntityConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Ads);
            builder.HasMany(c => c.Comments);
            builder.HasMany(c => c.Tags);
            builder.HasOne(c => c.Creator).WithMany(cr => cr.Contents);
        }
    }
}