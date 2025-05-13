using Joshua2.Data;
using Joshua2.Models;
using System.Linq;

namespace Joshua2.Data
{
    public static class DbInitializer
    {

        public static void Seed(ApplicationDbContext context)
        {
            // Asegúrate de que la base de datos esté creada
            context.Database.EnsureCreated();

            // Evitar duplicar datos de prueba
            if (context.Artistas.Any()) return;

            // Datos de prueba
            var artistas = new[]
            {
            new Artista { Nombre = "The Beatles" },
            new Artista { Nombre = "Queen" },
            new Artista { Nombre = "Taylor Swift" }
        };

            context.Artistas.AddRange(artistas);
            context.SaveChanges();
            try
            {
                DbInitializer.Seed(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ ERROR al sembrar la base de datos:");
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("➡️ Inner exception:");
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }
    }
}


