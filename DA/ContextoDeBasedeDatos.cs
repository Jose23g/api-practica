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
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Presentacion> Presentacion { get; set; }

        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Unidad_Medida> Unidad_Medida { get; set; }
        public DbSet<ProductoProveedores> ProductoProveedores { get; set; }

        public ContextoDeBasedeDatos(DbContextOptions<ContextoDeBasedeDatos> opciones) : base(opciones)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* builder.Entity<ProductoProveedores>()
                .HasKey(m => new { m.id_proveedor, m.id_producto });*/
            modelBuilder.Entity<ProductoProveedores>()
           .HasKey(pp => new { pp.id_producto, pp.id_proveedor });

            modelBuilder.Entity<ProductoProveedores>()
                .HasOne(pp => pp.Producto)
                //.WithMany(p => p.Proveedores)
                .WithMany(p => p.ProductoProveedores)
                .HasForeignKey(pp => pp.id_producto);

            modelBuilder.Entity<ProductoProveedores>()
                .HasOne(pp => pp.Proveedores)
                //.WithMany(p => p.Productos)
                .WithMany(p => p.ProductoProveedores)
                .HasForeignKey(pp => pp.id_proveedor);
            modelBuilder.Entity<ProductoProveedores>()
                .Property(pp => pp.Precio);

            base.OnModelCreating(modelBuilder);
        }
    }

}
