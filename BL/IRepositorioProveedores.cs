using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IRepositorioProveedores
    {
        List<Proveedores> listarProveedores();
        List<Proveedores> listarconproductos();
        public Proveedores ingresarproveedor(Proveedores proveedor);

        public Boolean existeproveedor(Proveedores proveedor);

    }
}
