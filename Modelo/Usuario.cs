using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario : IdentityUser

    {
        public char Sexo { get; set; }
        public string Pais { get; set; }
    }
}
