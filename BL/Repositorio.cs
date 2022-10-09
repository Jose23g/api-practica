using DA;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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

        public void ingresar(Album album)
        {
            Album temporal = new Album();
            temporal = album; 
            ElContextoBD.Add(temporal);  
            
        }

        public List<Album> Obtenertodo()
        {
            List<Album> albums;
            albums = ElContextoBD.Album.ToList();
           return albums;
        }

       

    }
}