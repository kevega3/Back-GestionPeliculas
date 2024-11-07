namespace peliculas.Models
{
    public class Carrito
    {
        public int idUsuario { set; get; }
        public int idPelicula { set; get; }

        public Usuario Usuario { set; get; }
        public Pelicula Pelicula { set; get; }
    }
}
