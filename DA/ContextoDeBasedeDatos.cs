using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Modelo;
using System.Configuration.Internal;

namespace DA
{
    public class ContextoDeBasedeDatos: DbContext
    {
        public DbSet<Album> Album { get; set; }

        public ContextoDeBasedeDatos(DbContextOptions<ContextoDeBasedeDatos> opciones) : base(opciones)
        {

        }
    }

}
