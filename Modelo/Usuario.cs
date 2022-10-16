using Microsoft.AspNetCore.Identity;

namespace Modelo
{
    public class Usuario : IdentityUser

    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
