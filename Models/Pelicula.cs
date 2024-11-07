using System.ComponentModel.DataAnnotations;

namespace peliculas.Models
{
    public class Pelicula
    {
        [Key]
        public int idPelicula { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int Anio { get; set; }
        public int Duracion { get; set; }
        public string Genero { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Actores { get; set; } = string.Empty;
        public string Sinopsis { get; set; } = string.Empty;
        public string Portada { get; set; } = string.Empty;
        
        public byte Estrellas { get; set; }
        public decimal Precio { get; set; }
        public List<Favorito>? Favorito { get; set; }
        public List<Carrito>? Carito { get; set; }


    }
}
