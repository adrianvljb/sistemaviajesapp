using System.Data;
using Microsoft.Data.SqlClient;

namespace SistemaViajesApp
{
    public class EmpleadosService
    {
        private readonly ConexionDB _conexion = new ConexionDB();

        public DataTable ListarActivos()
        {
            using (SqlConnection conn = _conexion.GetConnection())
            {
                conn.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT 
                        e.IdEmpleado,
                        e.Nombre,
                        s.Nombre AS Sucursal,
                        es.DistanciaKm
                      FROM EmpleadoSucursal es
                      INNER JOIN Empleados e ON es.IdEmpleado = e.IdEmpleado
                      INNER JOIN Sucursales s ON es.IdSucursal = s.IdSucursal
                      WHERE e.Activo = 1
                      ORDER BY e.Nombre;", conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public int Insertar(string nombre, int idSucursal, decimal distancia, int usuarioRegistro)
        {
            using (SqlConnection conn = _conexion.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tx = conn.BeginTransaction())
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = tx;

                    cmd.CommandText = "INSERT INTO Empleados (Nombre, Activo) OUTPUT INSERTED.IdEmpleado VALUES (@nombre, 1)";
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    int nuevoId = (int)cmd.ExecuteScalar();

                    cmd.Parameters.Clear();
                    cmd.CommandText = @"INSERT INTO EmpleadoSucursal 
                                        (IdEmpleado, IdSucursal, DistanciaKm, UsuarioRegistro)
                                        VALUES (@idEmp, @idSuc, @dist, @usr)";
                    cmd.Parameters.AddWithValue("@idEmp", nuevoId);
                    cmd.Parameters.AddWithValue("@idSuc", idSucursal);
                    cmd.Parameters.AddWithValue("@dist", distancia);
                    cmd.Parameters.AddWithValue("@usr", usuarioRegistro);
                    cmd.ExecuteNonQuery();

                    tx.Commit();
                    return nuevoId;
                }
            }
        }

        public void Actualizar(int idEmpleado, string nombre, int idSucursal, decimal distancia)
        {
            using (SqlConnection conn = _conexion.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tx = conn.BeginTransaction())
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = tx;

                    cmd.CommandText = "UPDATE Empleados SET Nombre = @nombre WHERE IdEmpleado = @idEmp";
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@idEmp", idEmpleado);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.CommandText = @"UPDATE EmpleadoSucursal
                                        SET IdSucursal = @idSuc,
                                            DistanciaKm = @dist
                                        WHERE IdEmpleado = @idEmp";
                    cmd.Parameters.AddWithValue("@idEmp", idEmpleado);
                    cmd.Parameters.AddWithValue("@idSuc", idSucursal);
                    cmd.Parameters.AddWithValue("@dist", distancia);
                    cmd.ExecuteNonQuery();

                    tx.Commit();
                }
            }
        }

        public void Desactivar(int idEmpleado)
        {
            using (SqlConnection conn = _conexion.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Empleados SET Activo = 0 WHERE IdEmpleado = @idEmp", conn))
                {
                    cmd.Parameters.AddWithValue("@idEmp", idEmpleado);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
