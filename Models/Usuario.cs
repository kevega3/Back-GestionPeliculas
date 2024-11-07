using System.ComponentModel.DataAnnotations;

namespace peliculas.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; } = string.Empty;
        public List<Favorito> Favorito { get; set; }
        public List<Carrito> Carito { get; set; }
    }
}
