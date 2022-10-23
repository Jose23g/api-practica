using Modelo;

namespace BL
{
    public interface IRepositorioUsuarios
    {
        Task<Response> Registrar(RegisterModel UserNuevo);
        Task<Response> LoginUsuario(RegisterModel UserNuevo);
    }
}
