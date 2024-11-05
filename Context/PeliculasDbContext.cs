using Microsoft.EntityFrameworkCore;
using peliculas.Models;

namespace peliculas.Context
{
    public class PeliculasDbContext : DbContext
    {
        public PeliculasDbContext(DbContextOptions<PeliculasDbContext> options) : base(options)
        {

        }
        public DbSet<Pelicula> Pelicula { get; set; }


        //public DbSet<Pelicula> Peliculas { get; set; }
    }
}
