using DA;
using Modelo;

namespace BL
{
    public class Repositorio : IRepositorio
    {
        private ContextoDeBasedeDatos ElContextoBD;

        public Repositorio(ContextoDeBasedeDatos elContextoBD)
        {
            ElContextoBD= elContextoBD;
        }

        public List<Album> Obtenertodo()
        {
            List<Album> albums;
            albums = ElContextoBD.Album.ToList();
           return albums;
        }
    }
}