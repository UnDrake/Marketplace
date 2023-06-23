using Marketplace.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(builder =>
            {
                builder.HasKey(i => i.Id);
                builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

                builder.HasOne(i => i.Sale)
                .WithOne(s => s.Item)
                .HasForeignKey<Sale>(s => s.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Sale>(builder =>
            {
                builder.HasKey(s => s.Id);
            });
        }
    }
}
