using Microsoft.EntityFrameworkCore;
using PhotoApp.Models;

namespace PhotoApp.Data
{
    public class PhotoDbContext : DbContext
    {
        public PhotoDbContext(DbContextOptions<PhotoDbContext> options) : base(options)
        {
        }

        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>().ToTable("Photo");
        }
    }
}