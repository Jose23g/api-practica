
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IRepositorioInventario
    {
        List<Inventario> listarInventario();
        Inventario obtenerInventario(int id_inventario);
        Inventario actualizarInventario(int id_inventario, Inventario actualizado);

    }
}
