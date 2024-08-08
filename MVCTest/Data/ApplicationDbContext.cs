using Microsoft.EntityFrameworkCore;
using MVCTest.Models;

namespace MVCTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Musics> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; } 
    }
}
