using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IRepositorioProductos
    {
        List<Producto> ListarProductos();
        Producto IngresarProducto( Producto producto);
        Unidad_Medida verificarUnidad (Unidad_Medida unidad);
        Presentacion verificarpresentacion(Presentacion presentacion);

        public Producto registrarproveedor(int codigopoducto, int cedulajuridica, float precio);
        public Boolean existecodigo(Producto producto);    
    
    }
}
