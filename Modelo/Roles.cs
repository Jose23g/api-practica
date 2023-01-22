using Microsoft.AspNetCore.Identity;

namespace Modelo
{
    public class Roles: IdentityRole
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
