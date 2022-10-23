using BL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Modelo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly UserManager<Usuario> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly IRepositorioUsuarios _repositorioUsuarios;
        public AutenticacionController(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IRepositorioUsuarios repositorioUsuarios)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            this._repositorioUsuarios = repositorioUsuarios;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in await userManager.GetRolesAsync(user))
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                DateTime tiempo = DateTime.Now;
                tiempo = tiempo.AddHours(1);
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: tiempo,
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();


        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response() { Status = "Error", Message = "User already exists!" });

            Usuario user = new Usuario()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            Usuario user = new Usuario()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(RolesUsuario.Admin))
                await roleManager.CreateAsync(new IdentityRole(RolesUsuario.Admin));
            if (!await roleManager.RoleExistsAsync(RolesUsuario.User))
                await roleManager.CreateAsync(new IdentityRole(RolesUsuario.User));

            if (await roleManager.RoleExistsAsync(RolesUsuario.Admin))
            {
                await userManager.AddToRoleAsync(user, RolesUsuario.Admin);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("NuevoUser")]
        public async Task<IActionResult> RegistrarNuevo([FromBody] RegisterModel nuevo)
        {
            Response response = await _repositorioUsuarios.Registrar(nuevo);
            if (!response.code)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        [Route("LoginUsuario")]
        public async Task<IActionResult> LoginUsuario([FromBody] RegisterModel usuario)
        {
            Response response = await _repositorioUsuarios.LoginUsuario(usuario);
            if (!response.code)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
