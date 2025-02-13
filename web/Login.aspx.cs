using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ReservasSalones.web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Puedes agregar lógica aquí si es necesario.
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string usuario = TextBox1.Text; // Correo electrónico
            string contrasena = TextBox2.Text; // Contraseña

            // Verificar si los campos están vacíos (esto ya se maneja con RequiredFieldValidators).
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                // Aquí puedes mostrar un mensaje de error o realizar otras acciones.
                return;
            }

            // Cadena de conexión a la base de datos utilizando el nombre de la conexión definida en web.config.
            string connectionString = WebConfigurationManager.ConnectionStrings["SistemaDeReservasConnectionString"].ToString();

            // Consulta SQL para validar el usuario y la contraseña con los nombres correctos de la tabla y los campos
            string query = "SELECT COUNT(*) FROM Usuario WHERE email = @Email AND contrasena = @Contrasena";

            // Crear una conexión y un comando.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Agregar los parámetros para evitar inyecciones SQL.
                    cmd.Parameters.AddWithValue("@Email", usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                    try
                    {
                        conn.Open();

                        // Ejecutar la consulta y obtener el resultado.
                        int result = (int)cmd.ExecuteScalar();

                        if (result > 0)
                        {
                            // Si el usuario existe y la contraseña es correcta, redirigir a Paso1.aspx
                            Response.Redirect("Paso1.aspx");
                        }
                        else
                        {
                            // Si el usuario o la contraseña son incorrectos.
                            // Mostrar un mensaje de error.
                            Response.Write("<script>alert('Usuario o contraseña incorrectos.');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Mostrar detalles completos del error para diagnóstico 
                        Response.Write("<script>alert('Error: " + ex.ToString() + "');</script>");
                    }
                }
            }
        }
    }
}


