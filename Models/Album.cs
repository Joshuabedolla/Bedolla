namespace Joshua2.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int Anio { get; set; } // Asegúrate de que sea "Anio"
        public int ArtistaId { get; set; }
        public Artista? Artista { get; set; }
        public ICollection<Cancion> Canciones { get; set; }
    }
}
