using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities;

namespace Misty.Persistence
{
    public class MistyContext : DbContext
    {
        public MistyContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}