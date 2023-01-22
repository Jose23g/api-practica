using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IRepositorioProveedor
    {
        Proveedores nuevoProveedor(Proveedores proveedor);
        List<Proveedores> listaProveedor();
    }
}
