using Microsoft.Data.SqlClient;
using System.Data;

namespace SistemaViajesApp
{
    public class TransportistasService
    {
        private readonly ConexionDB _conexion = new ConexionDB();

        public DataTable ListarActivos()
        {
            using (SqlConnection conn = _conexion.GetConnection())
            {
                conn.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT IdTransportista, Nombre
                      FROM Transportistas
                      WHERE Activo = 1
                      ORDER BY Nombre;", conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public int Insertar(string nombre)
        {
            using (SqlConnection conn = _conexion.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Transportistas (Nombre, Activo) OUTPUT INSERTED.IdTransportista VALUES (@nombre, 1)", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Actualizar(int idTransportista, string nombre)
        {
            using (SqlConnection conn = _conexion.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Transportistas SET Nombre = @nombre WHERE IdTransportista = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@id", idTransportista);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Desactivar(int idTransportista)
        {
            using (SqlConnection conn = _conexion.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Transportistas SET Activo = 0 WHERE IdTransportista = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", idTransportista);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
