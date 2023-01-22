﻿using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IRepositorioProductos
    {
        Producto nuevoProducto(Producto producto);
        List<Producto> listaProductos();
    }
}