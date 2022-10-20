using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IRepositorioUsuarios
    {
        Task<Response> Registrar(RegisterModel UserNuevo);
        Task<Response> LoginUsuario(RegisterModel UserNuevo);
    }
}
