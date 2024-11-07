using Microsoft.AspNetCore.Mvc;
using peliculas.Context;
using peliculas.Models;

namespace peliculas.Controllers
{
    [Route("api/[controller]")]
    public class FavoritoController : Controller
    {

        //private readonly PeliculaController context;
        private readonly PeliculasDbContext context;

        public FavoritoController(PeliculasDbContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(context.Favorito.Select(p=> p.Pelicula));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Agregar([FromBody] Favorito favorito)
        {
            try
            {

                var exists = context.Favorito.Any(c => c.idUsuario == favorito.idUsuario && c.idPelicula == favorito.idPelicula);
                if (!exists)
                {
                    context.Favorito.Add(favorito);
                    
                }
                context.SaveChanges();


                //context.Favorito.Add(favorito);
                //context.SaveChanges();
                return Ok(favorito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Eliminar([FromBody] Favorito favorito)
        {
            try
            {
                var exists = context.Favorito.Any(c => c.idUsuario == favorito.idUsuario && c.idPelicula == favorito.idPelicula);
                if (exists)
                {
                    context.Favorito.Remove(favorito);

                }
                //context.Favorito.Remove(favorito);
                context.SaveChanges();
                return Ok(favorito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
