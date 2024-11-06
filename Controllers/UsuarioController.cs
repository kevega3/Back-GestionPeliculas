using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using peliculas.Context;
using peliculas.Models;


namespace peliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase // Fixed typo in class name
    {
        private readonly PeliculasDbContext context;


        public UsuarioController(PeliculasDbContext context)
        {
            this.context = context;
        }

        [HttpPost]

        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                context.Usuario.Add(usuario);
                context.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }
    }
}