using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Misty.Domain.Entities;
using Misty.Domain.Entities.Users;

namespace Misty.Persistence.Configurations
{
    public class RegisteredUserEntityConfiguration : IEntityTypeConfiguration<RegisteredUser>
    {
        public void Configure(EntityTypeBuilder<RegisteredUser> builder)
        {
            builder.HasKey(u => u.Id);
        }
    }
}