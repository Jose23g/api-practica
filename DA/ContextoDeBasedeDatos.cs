using Microsoft.EntityFrameworkCore;
using Modelo;

namespace DA
{
    public class ContextoDeBasedeDatos : DbContext
    {
        public DbSet<user> user { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Detalle_pedido> Detalle_pedido { get; set; }
        public DbSet<Entrada> Entrada { get; set; }
        public DbSet<Detalle__entrada> Detalle_entrada { get; set; }
        public DbSet<Inventario> Inventario { get; set; }


        public ContextoDeBasedeDatos(DbContextOptions<ContextoDeBasedeDatos> opciones) : base(opciones)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           /* builder.Entity<ProductoProveedores>()
                .HasKey(m => new { m.id_proveedor, m.id_producto });*/
            base.OnModelCreating(builder);
        }
    }

}
