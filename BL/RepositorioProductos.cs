using DA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Modelo;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private ContextoDeBasedeDatos ElContextoBD;

        public RepositorioProductos(ContextoDeBasedeDatos contextoDeBasedeDatos)
        {
            this.ElContextoBD = contextoDeBasedeDatos;
        }


        public Producto IngresarProducto(Producto producto)
        {
            if (existecodigo(producto) == false) {

                producto.Presentacion = verificarpresentacion(producto.Presentacion);
                producto.Unidad_Medida = verificarUnidad(producto.Unidad_Medida);

                ElContextoBD.Producto.Add(producto);
                ElContextoBD.SaveChanges();

                return producto;

            }
            throw new NotImplementedException("El codigo ya existe neiro");
        }

        public List<Producto> ListarProductos()
        {
            return ElContextoBD.Producto.Include("Unidad_Medida").Include("Presentacion").ToList();
        }

        public Presentacion verificarpresentacion(Presentacion presentacion)
        {
            Presentacion presentacionnueva = new Presentacion();
            presentacionnueva = ElContextoBD.Presentacion.Where(p => p.Nombre.ToLower() == presentacion.Nombre.ToLower()).FirstOrDefault();

            if (presentacionnueva == null)
            {
                ElContextoBD.Presentacion.Add(presentacion);
                ElContextoBD.SaveChanges();
                return presentacion;
            }
            return presentacionnueva;
        }

        public Boolean existecodigo(Producto producto)
        {
            Producto productoverificar = ElContextoBD.Producto.Where(p => p.codigo_producto == producto.codigo_producto).FirstOrDefault();

            if (productoverificar == null)
            {
                return false;
            }

            return true;

        }

        public Unidad_Medida verificarUnidad(Unidad_Medida unidad)
        {
            Unidad_Medida nuevaunidad = new Unidad_Medida();

            nuevaunidad = ElContextoBD.Unidad_Medida.Where(u => u.Nombre.ToLower() == unidad.Nombre.ToLower()).FirstOrDefault();

            if (nuevaunidad == null) {
                ElContextoBD.Unidad_Medida.Add(unidad);
                ElContextoBD.SaveChanges();
                return unidad;
            }

            return nuevaunidad;
        }

        public Producto registrarproveedor(int codigopoducto, int cedulajuridica, float precio)
        {
            Producto productobuscar = ElContextoBD.Producto.Where(p => p.codigo_producto == codigopoducto).FirstOrDefault();
            Proveedores proveedor = ElContextoBD.Proveedores.Where(pr => pr.Cedula_juridica == cedulajuridica).FirstOrDefault();
            

            if (productobuscar != null)
            {
                ProductosProveedores nuevoproveedorproducto = new ProductosProveedores();
                nuevoproveedorproducto.Producto = productobuscar;
                nuevoproveedorproducto.Proveedor = proveedor;
                ElContextoBD.ProductoProveedores.Add(nuevoproveedorproducto);
                ElContextoBD.SaveChanges();
            }

            return productobuscar;
        } 


    }
}
