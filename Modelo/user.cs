using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class user : IdentityUser

    {
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public int cedula { get; set; }

    }
}
