using Joshua2.Models;
namespace Joshua2.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            if (context.Artistas.Any()) return;

            context.Artistas.AddRange(
                new Artista { Nombre = "The Beatles", Pais = "UK" },
                new Artista { Nombre = "Adele", Pais = "UK" }
            );
            context.SaveChanges();
        }
    }
}

