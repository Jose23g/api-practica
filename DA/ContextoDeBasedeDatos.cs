using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace DA
{
    public class ContextoDeBasedeDatos : DbContext
    {
        public DbSet<user> user { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Producto> Producto { get; set; }

        public ContextoDeBasedeDatos(DbContextOptions<ContextoDeBasedeDatos> opciones) : base(opciones)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

}
