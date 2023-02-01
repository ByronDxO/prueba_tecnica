using System.Security.Claims;

namespace Prueba_Tecnica_
{
    // clase para armar el token y sus diferentes props 
    public class Jwt
    {

        public string Key { get; set; }
        public string Issuer { get; set; }

        public string Audience { get; set; }
        public string Subject { get; set; }

        // metodo para validar el token generado 
        public static dynamic validarToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0)
                {
                    return new
                    {
                        success = false,
                        message = "Verificar Token Valido",
                        result = ""
                    };

                }
                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;
                Usuario usuario = Usuario.DB().FirstOrDefault(x => x.id_usuario == id);
                return new
                {
                    success = true,
                    message = "Verificado",
                    result = usuario
                };

            } 
            catch (Exception ex)
            {


                return new
                {
                    success = false,
                    message = "catch:"+ ex.Message,
                    result = ""

                };
            }
        }
    }
}
