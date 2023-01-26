using DA;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private ContextoDeBasedeDatos ElContextoBD;

        public RepositorioProductos(ContextoDeBasedeDatos _elContextoBD)
        {
            ElContextoBD= _elContextoBD;
        }

        public Presentacion getIdPrecentacion(string nombre)
        {
            try
            {
                var presentacion = ElContextoBD.Presentacion
                                              .Where(x => x.Nombre==nombre)
                                                .FirstOrDefault();
                if (presentacion == null)
                {
                    Presentacion nuevo = new Presentacion();
                    nuevo.Nombre = nombre;
                    ElContextoBD.Presentacion.Add(nuevo);
                    ElContextoBD.SaveChanges();
                    return nuevo;
                }
                return presentacion;
            }
            catch(Exception e)
            {
                Presentacion presentacion= new Presentacion();
                return presentacion;
            }
        }

        public Unidad_Medida getIdUnidad_Medida(string nombre)
        {
            var unidad = ElContextoBD.Unidad_Medida
                .Where(x=>x.Nombre == nombre)
                .FirstOrDefault();
            if (unidad == null)
            {
                Unidad_Medida unidad_Medida= new Unidad_Medida();
                unidad_Medida.Nombre= nombre;
                ElContextoBD.Unidad_Medida.Add(unidad_Medida);
                ElContextoBD.SaveChanges();
                return unidad_Medida;
            }

            return unidad;
        }

        public List<Presentacion> listaPresentaciones()
        {
            return  ElContextoBD.Presentacion.ToList();
        }

        public List<Producto> listaProductos()
        {
           return ElContextoBD.Producto.ToList();
        }

        public List<Unidad_Medida> listaUnidades()
        {
           return ElContextoBD.Unidad_Medida.ToList();
        }

        public Producto nuevoProducto(Producto producto)
        {
            try
            {
             

                ElContextoBD.Producto.Add(producto);
                ElContextoBD.SaveChanges();
                return producto;

            }catch(Exception ex)
            {
                return producto;
            }
        }
    }
}
