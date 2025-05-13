using Microsoft.EntityFrameworkCore;
using Joshua2.Models;

namespace Joshua2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cancion> Canciones { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artista> Artistas { get; set; }
    }
}

