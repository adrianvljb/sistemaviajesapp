using Microsoft.Data.SqlClient;

namespace SistemaViajesApp.Security
{
    public class AuthService
    {
        public string? ValidarUsuario(string usuario, string contrasena)
        {
            usuario = (usuario ?? "").Trim();
            contrasena = (contrasena ?? "").Trim();

            if (usuario.Length == 0 || contrasena.Length == 0)
                return null;

            var db = new ConexionDB();
            using SqlConnection conn = db.GetConnection();
            conn.Open();

            string sql = @"
                SELECT Rol
                FROM Usuarios
                WHERE Usuario = @Usuario
                  AND Contrasena = @Contrasena
                  AND Activo = 1;";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Usuario", usuario);
            cmd.Parameters.AddWithValue("@Contrasena", contrasena);

            object? resultado = cmd.ExecuteScalar();
            return resultado?.ToString();
        }
    }
}