using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace DA
{
    public class ContextoDeBasedeDatos : DbContext
    {
        public DbSet<Album> Album { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        public ContextoDeBasedeDatos(DbContextOptions<ContextoDeBasedeDatos> opciones) : base(opciones)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

}
