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

        public Album BuscarId(int id)
        {
            Album albumbuscado = new Album();

            albumbuscado = ElContextoBD.Album.Find(id);
            return albumbuscado;
        }

        public Album Editar(Album Amodificar)
        {
            Album albumaeditar = new Album();
            albumaeditar = BuscarId(Amodificar.id);

            albumaeditar.ArtisName = Amodificar.ArtisName;
            albumaeditar.Price = Amodificar.Price;
            albumaeditar.Name = Amodificar.Name;
            albumaeditar.genre = Amodificar.genre;
            albumaeditar.id=Amodificar.id;
            ElContextoBD.Album.Update(albumaeditar);
            ElContextoBD.SaveChanges();

            return albumaeditar;
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
            catch(Exception e)
            {
               return album;
            }
           
        }

        public List<Album> Obtenertodo()
        {
            List<Album> albums;
            albums = ElContextoBD.Album.ToList();
           return albums;
        }

       

    }
}