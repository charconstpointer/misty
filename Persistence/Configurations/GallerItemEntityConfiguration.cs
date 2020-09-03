using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misty.Domain.Entities.Content.Gallery;
using Misty.Domain.ValueObjects;

namespace Misty.Persistence.Configurations
{
    public class GalleryItemEntityConfiguration : IEntityTypeConfiguration<GalleryItem>
    {
        public void Configure(EntityTypeBuilder<GalleryItem> builder)
        {
            builder.HasKey(g => g.Id);
            builder.OwnsOne(g=>g.Resolution).WithOwner();
        }
    }
}