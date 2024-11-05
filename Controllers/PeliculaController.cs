using Microsoft.AspNetCore.Mvc;
using peliculas.Context;

namespace peliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase // Fixed typo in class name
    {
        private readonly PeliculasDbContext context;
        public PeliculaController(PeliculasDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Pelicula.Select(P => new
                {
                    P.idPelicula,
                    P.Titulo,
                    P.Anio,
                    P.Duracion,
                    P.Genero,
                    P.Director,
                    P.Actores,
                    P.Sinopsis,
                    P.Portada,
                    P.Estrellas,
                    P.Precio
                }).ToList());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]/{valor}")]
        [HttpGet("BuscarPor")]
        public ActionResult BuscarPor(string valor)
        {
            try
            {
                return Ok(context.Pelicula.Select(p =>
                    new {
                        p.idPelicula,
                        p.Titulo,
                        p.Anio,
                        p.Duracion,
                        p.Genero,
                        p.Director,
                        p.Actores,
                        p.Sinopsis,
                        p.Portada,
                        p.Estrellas,
                        p.Precio
                    }).Where(p => p.Genero.Contains(valor) ||
                    p.Titulo.Contains(valor) ||
                    p.Director.Contains(valor) ||
                    p.Actores.Contains(valor) ||
                    p.Genero.Contains(valor)));
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}