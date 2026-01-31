using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace SistemaViajesApp.Services
{
    public sealed class LogService
    {
        public void Registrar(LogEntry entry)
        {
            using var cn = new ConexionDB().GetConnection();
            cn.Open();

            const string sql = @"
INSERT INTO dbo.Logs
(FechaHora, IdUsuario, Usuario, Rol, Modulo, Accion, Detalle, Exitoso, Ip)
VALUES
(GETDATE(), @IdUsuario, @Usuario, @Rol, @Modulo, @Accion, @Detalle, @Exitoso, @Ip);";

            using var cmd = new SqlCommand(sql, cn);

            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value =
                entry.IdUsuario.HasValue ? entry.IdUsuario.Value : DBNull.Value;

            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value =
                string.IsNullOrWhiteSpace(entry.Usuario) ? DBNull.Value : entry.Usuario.Trim();

            cmd.Parameters.Add("@Rol", SqlDbType.VarChar, 50).Value =
                string.IsNullOrWhiteSpace(entry.Rol) ? DBNull.Value : entry.Rol.Trim();

            cmd.Parameters.Add("@Modulo", SqlDbType.VarChar, 50).Value = entry.Modulo.Trim();
            cmd.Parameters.Add("@Accion", SqlDbType.VarChar, 100).Value = entry.Accion.Trim();

            cmd.Parameters.Add("@Detalle", SqlDbType.VarChar, 500).Value =
                string.IsNullOrWhiteSpace(entry.Detalle) ? DBNull.Value : entry.Detalle.Trim();

            cmd.Parameters.Add("@Exitoso", SqlDbType.Bit).Value = entry.Exitoso;

            cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50).Value =
                string.IsNullOrWhiteSpace(entry.Ip) ? DBNull.Value : entry.Ip.Trim();

            cmd.ExecuteNonQuery();
        }

        public DataTable Listar(DateTime desde, DateTime hasta, string? modulo, string? usuario, bool? exitoso)
        {
            using var cn = new ConexionDB().GetConnection();
            cn.Open();

            const string sql = @"
SELECT
    IdLog,
    FechaHora,
    IdUsuario,
    Usuario,
    Rol,
    Modulo,
    Accion,
    Detalle,
    Exitoso,
    Ip
FROM dbo.Logs
WHERE FechaHora >= @Desde
  AND FechaHora < DATEADD(DAY, 1, @Hasta)
  AND (@Modulo IS NULL OR LTRIM(RTRIM(Modulo)) = @Modulo)
  AND (@Usuario IS NULL OR LTRIM(RTRIM(Usuario)) = @Usuario)
  AND (@Exitoso IS NULL OR Exitoso = @Exitoso)
ORDER BY FechaHora DESC, IdLog DESC;";

            using var cmd = new SqlCommand(sql, cn);

            cmd.Parameters.Add("@Desde", SqlDbType.Date).Value = desde.Date;
            cmd.Parameters.Add("@Hasta", SqlDbType.Date).Value = hasta.Date;

            cmd.Parameters.Add("@Modulo", SqlDbType.VarChar, 50).Value =
    string.IsNullOrWhiteSpace(modulo) ? DBNull.Value : modulo.Trim();

            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value =
                string.IsNullOrWhiteSpace(usuario) ? DBNull.Value : usuario.Trim();

            cmd.Parameters.Add("@Exitoso", SqlDbType.Bit).Value =
                exitoso.HasValue ? exitoso.Value : DBNull.Value;

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable ListarUsuariosEnLogs()
        {
            using var cn = new ConexionDB().GetConnection();
            cn.Open();

            const string sql = @"
SELECT DISTINCT Usuario
FROM dbo.Logs
WHERE Usuario IS NOT NULL AND LTRIM(RTRIM(Usuario)) <> ''
ORDER BY Usuario;";

            using var da = new SqlDataAdapter(sql, cn);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

    public sealed class LogEntry
    {
        public int? IdUsuario { get; set; }
        public string? Usuario { get; set; }
        public string? Rol { get; set; }
        public string Modulo { get; set; } = "";
        public string Accion { get; set; } = "";
        public string? Detalle { get; set; }
        public bool Exitoso { get; set; }
        public string? Ip { get; set; }
    }
}