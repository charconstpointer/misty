using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misty.Domain.Entities.Content;

namespace Misty.Persistence.Configurations
{
    public class ContentEntityConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Ads);
            builder.HasMany(c => c.Comments);
            builder.HasOne(c => c.Category).WithMany(cc => cc.Contents);
            builder.HasOne(c => c.Creator).WithMany(cr => cr.Contents);
            builder.OwnsMany(c => c.Tags);
        }
    }
}