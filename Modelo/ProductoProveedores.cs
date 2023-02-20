namespace Modelo
{
    public partial class ProductoProveedores
    {

        public int id_producto { get; set; }

        public int id_proveedores { get; set; }
        public double precio { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Proveedores Proveedores { get; set; }
    }
}
