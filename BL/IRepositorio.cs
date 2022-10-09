using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IRepositorio
    {
        List<Album> Obtenertodo();
        Album ingresar(Album album);
    } 

}
