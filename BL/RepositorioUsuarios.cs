using Microsoft.AspNetCore.Identity;
using Modelo;

namespace BL
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RepositorioUsuarios(UserManager<Usuario> userManager)
        {
            this._userManager = userManager;
        }
       
        public async Task<Response> Registrar(RegisterModel UserNuevo)
        {

            var usuarioExiste = await _userManager.FindByNameAsync(UserNuevo.Username);
            if (usuarioExiste != null)
            {
                return new Response() { code = false, Message = "El usuario ya existe", Status = "Error" };
            }
            Usuario usuario = new Usuario()
            {
                Email = UserNuevo.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = UserNuevo.Username
            };

            var Resultado = await _userManager.CreateAsync(usuario, UserNuevo.Password);

            if (!Resultado.Succeeded)
            {
                return new Response() { code = false, Message = "Error al crear usuario, Intentelo de nuevo", Status = "Error" };
            }

            return new Response() { code = true, Message = "Usuario creado con exito", Status = "Success" };
        }

        public async Task<Response> LoginUsuario(RegisterModel usuariologin)
        {
            var user = await _userManager.FindByNameAsync(usuariologin.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, usuariologin.Password))
            {
                return new Response() { code = true, Message = "Perfecto metido en el sistema", Status = "Success" };
            }
            else
            {
                return new Response() { code = false, Message = "Algo ocurrio", Status = "Error" };
            }


        }


    }
}
