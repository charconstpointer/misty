using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities;
using Misty.Domain.Entities.Content;
using Misty.Domain.Entities.Users;

namespace Misty.Persistence
{
    public class MistyContext : DbContext
    {
        public MistyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<RegisteredUser> Users { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<Advertiser> Advertisers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}