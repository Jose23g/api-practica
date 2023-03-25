using DA;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RepositorioProveedores : IRepositorioProveedores
    {
        private ContextoDeBasedeDatos ElcontextoBD ; 

        public RepositorioProveedores(ContextoDeBasedeDatos contexto)
        {
            this.ElcontextoBD = contexto;
        }

        public Proveedores ingresarproveedor(Proveedores proveedor)
        {
            Proveedores nuevoproveedor = proveedor;

            if (existeproveedor(proveedor) == false) {
                ElcontextoBD.Proveedores.Add(nuevoproveedor);
                ElcontextoBD.SaveChanges();

                return nuevoproveedor;
              } 
            throw new NotImplementedException("El Nombre o la Cedula Juridica ya se encuntra Regristada");
        }

        public List<Proveedores> listarconproductos()
        {
            List<Proveedores> proveedoresproducto = new List<Proveedores>();
            
            proveedoresproducto = ElcontextoBD.Proveedores.ToList();

            foreach(Proveedores proveedor in proveedoresproducto)
            {
                proveedor.ProductoProveedores = ElcontextoBD.ProductoProveedores.Where(x=> x.id_proveedor == proveedor.id_proveedor).ToList();

                foreach(ProductoProveedores pp_producto in proveedor.ProductoProveedores)
                {
                    pp_producto.Producto = ElcontextoBD.Producto.Where(x => x.id_producto == pp_producto.id_producto).FirstOrDefault();
                }
            }
      
            return proveedoresproducto;
        }

        public List<Proveedores> listarProveedores()
        {
            List<Proveedores> proveedores = new List<Proveedores>();
            proveedores = ElcontextoBD.Proveedores.ToList();

            return proveedores;
        }

        public bool existeproveedor(Proveedores proveedor)
        {  

            Proveedores proveedorbuscar = ElcontextoBD.Proveedores.Where(pr => (pr.Cedula_juridica == proveedor.Cedula_juridica) || (pr.Nombre.ToLower() == proveedor.Nombre.ToLower())).FirstOrDefault();

            if (proveedorbuscar == null)
            {
                return false;
            }

            return true;
        }
    }


    }

