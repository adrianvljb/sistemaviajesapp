using Microsoft.Data.SqlClient;

namespace SistemaViajesApp
{
    public class ConexionDB
    {
        private readonly string connectionString =
            @"Server=localhost\SQLEXPRESS;Database=SistemaViajes;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}