using Microsoft.EntityFrameworkCore;
using AlbumsGraphQL.Models;

namespace Data.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Artist>()
                .HasMany(p => p.Albums)
                .WithOne(p => p.Artist)
                .HasForeignKey(c => c.ArtistId);

            modelBuilder
                .Entity<Album>()
                .HasOne(c => c.Artist)
                .WithMany(p => p.Albums)
                .HasForeignKey(p => p.ArtistId);

            base.OnModelCreating(modelBuilder);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Artist> Artists { get; set; } 
        public DbSet<Album> Albums { get; set; }


    }
}
