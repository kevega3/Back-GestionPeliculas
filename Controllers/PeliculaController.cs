using Microsoft.AspNetCore.Mvc;
using peliculas.Context;
using peliculas.Models;

namespace peliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase // Fixed typo in class name
    {
        private readonly PeliculasDbContext context;

        public object Usuario { get; internal set; }

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
                    P.Precio,
                    Favorito = P.Favorito.Select(fa => new { fa.idPelicula, fa.idUsuario })
                    
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

        [Route("[action]/{estrellas}")]
        [HttpGet("GetDestacas")]
        public ActionResult GetDestacas(int estrellas)
        {
            try
            {
                return Ok(context.Pelicula.Select(p =>
                    new
                    {
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
                        p.Precio,
                        Favorito = p.Favorito.Select(fa => new { fa.idPelicula, fa.idUsuario })
                    }).Where(p => p.Estrellas >= estrellas));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}