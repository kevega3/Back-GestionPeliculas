namespace peliculas.Models
{
    public class Favorito
    {
        public int idUsuario { get; set; }
        public int idPelicula { get; set; }
        public Usuario Usuario { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}
