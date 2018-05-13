using Microsoft.EntityFrameworkCore;
using Persistence.Database.Config;
using Persistence.Database.Models;

namespace Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
        )
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AnexMusic;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new SongConfiguration(builder.Entity<Song>());

            base.OnModelCreating(builder);
        }
    }
}
