﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<ProductosProveedores> ProductoProveedores { get; set; }

        public ContextoDeBasedeDatos(DbContextOptions<ContextoDeBasedeDatos> opciones) : base(opciones)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<ProductosProveedores>()
                .HasKey(m => new { m.Producto.id_producto, m.Proveedor.id_proveedor });
            base.OnModelCreating(builder);
        }
    }

}
