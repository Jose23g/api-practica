using DA;
using Modelo;

namespace BL
{
    public class Repositorio : IRepositorio
    {
        private ContextoDeBasedeDatos ElContextoBD;

        public Repositorio(ContextoDeBasedeDatos elContextoBD)
        {
            ElContextoBD = elContextoBD;
        }

        public Album ingresar(Album album)
        {
            try
            {
                Album temporal = new Album();
                temporal = album;
                ElContextoBD.Add(temporal);
                ElContextoBD.SaveChanges();

                return temporal;
            }
            catch (Exception e)
            {
                return album;
            }

        }

        public List<Album> Obtenertodo()
        {
            // List<Album> albums = new Album();
            //albums = ElContextoBD.Album.ToList();

            return null;
        }



    }
}