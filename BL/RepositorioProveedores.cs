using DA;
using Modelo;
using System;
using System.Collections.Generic;
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
            proveedoresproducto = ElcontextoBD.Proveedores.Include("ProductoProveedores").ToList();

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

