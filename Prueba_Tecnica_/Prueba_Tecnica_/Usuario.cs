namespace Prueba_Tecnica_
{
    public class Usuario
    {
        // modelo de usuario 
        public string id_usuario { get; set; }
        public string usuario { get; set;}
        public string password { get; set;}

        public string rol { get; set; }

        // db temporal para pruebas sin bd 
        public static List<Usuario> DB() {

            var list = new List<Usuario>()
            {
                new Usuario
                {
                    id_usuario = "1",
                    usuario= "byron@gmail.com",
                    password="12345",
                    rol="admin"
                },
                new Usuario
                {
                    id_usuario = "2",
                    usuario= "byaaron@gmail.com",
                    password="12345",
                    rol="cliente"
                },
                new Usuario
                {
                    id_usuario = "3",
                    usuario= "bysssron@gmail.com",
                    password="12345",
                    rol="admin"
                }
            };
            return list;
            }
    }
}
