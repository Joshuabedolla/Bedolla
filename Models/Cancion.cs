namespace Joshua2.Models;
using System.ComponentModel.DataAnnotations;
public class Cancion
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El título es obligatorio.")]
    [StringLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "La duración es obligatoria.")]
    [RegularExpression(@"^\d{1,2}:\d{2}$", ErrorMessage = "La duración debe tener el formato mm:ss.")]
    public string Duracion { get; set; }

    [Required(ErrorMessage = "El artista es obligatorio.")]
    public string Artista { get; set; }

    [Required(ErrorMessage = "El género es obligatorio.")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "La fecha de lanzamiento es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime FechaLanzamiento { get; set; }

    [Required(ErrorMessage = "El álbum es obligatorio.")]
    public int AlbumId { get; set; }

    public Album Album { get; set; }
}




