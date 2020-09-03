using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misty.Domain.Entities;
using Misty.Domain.Entities.Users;

namespace Misty.Persistence.Configurations
{
    public class ContentVisitorEntityConfiguration : IEntityTypeConfiguration<ContentVisitor>
    {
        public void Configure(EntityTypeBuilder<ContentVisitor> builder)
        {
            builder.HasKey(cv => new {cv.ContentId, cv.VisitorId});
        }
    }
    
    public class VisitorEntityConfiguration : IEntityTypeConfiguration<Visitor>
    {
        public void Configure(EntityTypeBuilder<Visitor> builder)
        {
            builder.HasKey(v => v.Id);
        }
    }
}