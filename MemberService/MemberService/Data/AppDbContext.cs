using Microsoft.EntityFrameworkCore;
using MemberService.Models;

namespace MemberService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Member entity configuration using Fluent API
            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.FirstName)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(m => m.LastName)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(m => m.Email)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(m => m.Status)
                      .IsRequired()
                      .HasMaxLength(20);
                
            });
        }
    }
}
