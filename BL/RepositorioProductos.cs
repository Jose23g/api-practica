using DA;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Modelo;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
       
        public Presentacion existePresentacion(Presentacion presentacion)
        {
            Presentacion resultado = ElContextoBD.Presentacion.Where(x => x.Nombre.Equals(presentacion.Nombre)).FirstOrDefault();

            if (resultado != null)
            {
                return resultado;
            }

            ElContextoBD.Add(presentacion);
            ElContextoBD.SaveChanges();
            return presentacion;
        }

        public Unidad_Medida existeUnidad_Medida(Unidad_Medida unidad_Medida)
        {
            Unidad_Medida resultado = ElContextoBD.Unidad_Medida.Where(x => x.Nombre.Equals(unidad_Medida.Nombre)).FirstOrDefault();

            if (resultado != null)
            {
                return resultado;
            }

            ElContextoBD.Add(unidad_Medida);
            ElContextoBD.SaveChanges();
            return unidad_Medida;
        }

        public Producto nuevoProducto(Producto producto)
        {
            try
            {
                Producto nuevoProducto = producto;

                nuevoProducto.presentacion = existePresentacion(producto.presentacion);
                nuevoProducto.Unidad_Medida = existeUnidad_Medida(producto.Unidad_Medida);

               ElContextoBD.Producto.Add(nuevoProducto);
               ElContextoBD.SaveChanges();
               return producto;
                 
            }catch(Exception ex)
            {
                
                return producto;
            }
        }
    }
}
