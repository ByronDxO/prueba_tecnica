using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Prueba_Tecnica_.Controllers
{
    //Login sirve para validar el usuario y registrar el token 
    [ApiController]
    [Route("usuario")]
    public class UsuarioController: ControllerBase
    {
        
        public IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // cadena de conexion a una db 
        //static string cadena = "Data Source=(local);Initial Catalog=DB_ACCESO;Integrated Security=true";

        [HttpPost]
        [Route("Login")]
        public dynamic Login([FromBody]Object optData)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());
            string user = data.usuario.ToString();
            string pass = data.password.ToString();

           // decomentar para una conexion a una db 
           /* 
           Usuario user2 = new Usuario();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_Validar_Usuario", cn);
                cmd.Parameters.AddWithValue("@pUsuario", user);
                cmd.Parameters.AddWithValue("@pPassword", pass);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                data = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                user2 = data;
            }
            */

            Usuario usuario = Usuario.DB().Where(x=>x.usuario == user && x.password == pass).FirstOrDefault();

            if(usuario == null)
            {
                return new
                {
                    success = false,
                    message = "credenciales incorrectas",
                    result = ""
                };
            }
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id",usuario.id_usuario),
                new Claim("usuario",usuario.usuario)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: singIn
                    

                );
            return new
            {
                success = true,
                message = "exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        /// enpoint de eliminar funcinoa para validar los roles y los tokens al mometno de ingresar en el swap 
        //[Authorize] descomentar para permitir que solo puedan ingresar usuarios con token validos 
        [HttpPost]
        [Route("eliminar")]        
        public dynamic eliminarUsuario(Usuario usuario)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            
            var rtoken = Jwt.validarToken(identity);
            if (!rtoken.success) return rtoken;
            Usuario user = rtoken.result;

            if(user.rol != "admin")
            {
                return new
                {
                    success = false,
                    message = "no tienes permisos para eliminar clientes",
                    result = ""
                };
            }

            return new
            {
                success = true,
                message = "cliente eliminado",
                result = usuario
            };

        }
    }
}
