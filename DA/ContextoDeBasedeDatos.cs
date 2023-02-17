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
        public DbSet<Presentacion> Presentacion { get; set; }
        public DbSet<Unidad_Medida> Unidad_Medida { get; set; }
        public DbSet<ProductoProveedores> ProductoProveedores { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Detalle_pedido> Detalle_Pedidos { get; set; }


        public ContextoDeBasedeDatos(DbContextOptions<ContextoDeBasedeDatos> opciones) : base(opciones)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductoProveedores>()
                .HasKey(m => new { m.id_proveedores, m.id_producto });
            base.OnModelCreating(builder);
        }
    }

}
