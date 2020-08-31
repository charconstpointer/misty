using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misty.Domain.Entities;

namespace Misty.Persistence.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<RegisteredUser>
    {
        public void Configure(EntityTypeBuilder<RegisteredUser> builder)
        {
            builder.HasKey(u => u.Id);
        }
    }
}