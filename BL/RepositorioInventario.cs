using DA;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RepositorioInventario : IRepositorioInventario
    {
        private ContextoDeBasedeDatos ElContextoBD;
       
        public RepositorioInventario(ContextoDeBasedeDatos basedeDatos) 
        {
        
            ElContextoBD = basedeDatos;
        }
        
        public Inventario actualizarInventario(int id_inventario, Inventario actualizado)
        {
            try
            {
                
                Inventario inventario = obtenerInventario(id_inventario);
                inventario = actualizado;
                ElContextoBD.Inventario.Update(inventario);

                return inventario;
            
            }catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public List<Inventario> listarInventario()
        {
            try
            {
                var lista = ElContextoBD.Inventario.ToList();
                return lista;
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public Inventario obtenerInventario(int id_inventario)
        {
            try
            {
                Inventario inventario = ElContextoBD.Inventario.Find(id_inventario);
                
                if(inventario == null)
                {
                    throw new NotImplementedException("No se encontró dicho producto en inventario");
                }
                return inventario; 

            }catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
