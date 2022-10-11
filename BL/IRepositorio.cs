using Modelo;

namespace BL
{
    public interface IRepositorio
    {
        List<Album> Obtenertodo();
        Album ingresar(Album album);
    }

}
