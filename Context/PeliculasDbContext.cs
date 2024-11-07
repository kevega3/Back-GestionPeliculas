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
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Favorito> Favorito { get; set; }
        public DbSet<Carrito> Carrito { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorito>().HasKey(f => new { f.idUsuario, f.idPelicula });
            modelBuilder.Entity<Favorito>().HasOne(x => x.Usuario).WithMany(f => f.Favorito).HasForeignKey(u => u.idUsuario);
            modelBuilder.Entity<Favorito>().HasOne(x => x.Pelicula).WithMany(f => f.Favorito).HasForeignKey(f => f.idPelicula);
            modelBuilder.Entity<Carrito>().HasKey(x => new { x.idUsuario, x.idPelicula });
            modelBuilder.Entity<Carrito>().HasOne(x => x.Usuario).WithMany(f => f.Carito).HasForeignKey(u => u.idUsuario);
            modelBuilder.Entity<Carrito>().HasOne(x => x.Pelicula).WithMany(f => f.Carito).HasForeignKey(f => f.idPelicula);
        }
    }
}
