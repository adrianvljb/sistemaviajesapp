using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace SistemaViajesApp.Services
{
    public class ViajesService
    {
        private readonly ConexionDB _conexionDB = new ConexionDB();

        // Catalogs

        public List<SucursalDto> GetSucursales()
        {
            var lista = new List<SucursalDto>();

            using var cn = _conexionDB.GetConnection();
            cn.Open();

            const string sql = @"
SELECT IdSucursal, Nombre
FROM dbo.Sucursales
WHERE Activo = 1
ORDER BY Nombre;";

            using var cmd = new SqlCommand(sql, cn);
            using var rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                lista.Add(new SucursalDto
                {
                    IdSucursal = rd.GetInt32(0),
                    Nombre = rd.GetString(1)
                });
            }

            return lista;
        }

        public List<TransportistaDto> GetTransportistas()
        {
            var lista = new List<TransportistaDto>();

            using var cn = _conexionDB.GetConnection();
            cn.Open();

            const string sql = @"
SELECT IdTransportista, Nombre, TarifaPorKm
FROM dbo.Transportistas
WHERE Activo = 1
ORDER BY Nombre;";

            using var cmd = new SqlCommand(sql, cn);
            using var rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                lista.Add(new TransportistaDto
                {
                    IdTransportista = rd.GetInt32(0),
                    Nombre = rd.GetString(1),
                    TarifaPorKm = rd.GetDecimal(2)
                });
            }

            return lista;
        }

        public List<EmpleadoDto> GetEmpleados()
        {
            var lista = new List<EmpleadoDto>();

            using var cn = _conexionDB.GetConnection();
            cn.Open();

            const string sql = @"
SELECT IdEmpleado, Nombre
FROM dbo.Empleados
WHERE Activo = 1
ORDER BY Nombre;";

            using var cmd = new SqlCommand(sql, cn);
            using var rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                lista.Add(new EmpleadoDto
                {
                    IdEmpleado = rd.GetInt32(0),
                    Nombre = rd.GetString(1)
                });
            }

            return lista;
        }

        // Users

        public int ObtenerIdUsuarioPorUsuario(string usuario)
        {
            using var cn = _conexionDB.GetConnection();
            cn.Open();

            const string sql = @"
SELECT IdUsuario
FROM dbo.Usuarios
WHERE Usuario = @Usuario AND Activo = 1;";

            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Usuario", usuario);

            var result = cmd.ExecuteScalar();
            if (result == null)
                throw new Exception("Usuario no existe o está inactivo.");

            return Convert.ToInt32(result);
        }

        // Trips (Insert + Detail)

        public int InsertarViaje(ViajeGuardarRequest req)
        {
            using var cn = _conexionDB.GetConnection();
            cn.Open();

            using var tx = cn.BeginTransaction();

            try
            {
                const string sqlViaje = @"
INSERT INTO dbo.Viajes
(FechaViaje, IdSucursal, IdTransportista, UsuarioRegistro)
VALUES
(@FechaViaje, @IdSucursal, @IdTransportista, @UsuarioRegistro);

SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int idViaje;
                using (var cmd = new SqlCommand(sqlViaje, cn, tx))
                {
                    cmd.Parameters.AddWithValue("@FechaViaje", req.FechaViaje.Date);
                    cmd.Parameters.AddWithValue("@IdSucursal", req.IdSucursal);
                    cmd.Parameters.AddWithValue("@IdTransportista", req.IdTransportista);
                    cmd.Parameters.AddWithValue("@UsuarioRegistro", req.UsuarioRegistro);

                    idViaje = Convert.ToInt32(cmd.ExecuteScalar());
                }

                const string sqlDetalle = @"
INSERT INTO dbo.ViajeEmpleado
(IdViaje, IdEmpleado, DistanciaKm, TarifaCalculada)
VALUES
(@IdViaje, @IdEmpleado, @DistanciaKm, @TarifaCalculada);";

                foreach (var d in req.Detalle)
                {
                    using var cmdDet = new SqlCommand(sqlDetalle, cn, tx);
                    cmdDet.Parameters.AddWithValue("@IdViaje", idViaje);
                    cmdDet.Parameters.AddWithValue("@IdEmpleado", d.IdEmpleado);
                    cmdDet.Parameters.AddWithValue("@DistanciaKm", d.DistanciaKm);
                    cmdDet.Parameters.AddWithValue("@TarifaCalculada", d.TarifaCalculada);
                    cmdDet.ExecuteNonQuery();
                }

                tx.Commit();
                return idViaje;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        // Trips (Listing)

        public List<ViajeListadoDto> ListarViajes(DateTime desde, DateTime hasta, int? idSucursal, int? idTransportista)
        {
            var lista = new List<ViajeListadoDto>();

            using var cn = _conexionDB.GetConnection();
            cn.Open();

            const string sql = @"
SELECT  v.IdViaje,
        v.FechaViaje,
        s.Nombre AS Sucursal,
        t.Nombre AS Transportista,
        v.UsuarioRegistro,
        v.FechaHoraRegistro
FROM dbo.Viajes v
INNER JOIN dbo.Sucursales s ON s.IdSucursal = v.IdSucursal
INNER JOIN dbo.Transportistas t ON t.IdTransportista = v.IdTransportista
WHERE v.FechaViaje >= @Desde
  AND v.FechaViaje <= @Hasta
  AND (@IdSucursal IS NULL OR v.IdSucursal = @IdSucursal)
  AND (@IdTransportista IS NULL OR v.IdTransportista = @IdTransportista)
ORDER BY v.FechaViaje DESC, v.IdViaje DESC;";

            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Desde", desde.Date);
            cmd.Parameters.AddWithValue("@Hasta", hasta.Date);
            cmd.Parameters.AddWithValue("@IdSucursal", (object?)idSucursal ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IdTransportista", (object?)idTransportista ?? DBNull.Value);

            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                lista.Add(new ViajeListadoDto
                {
                    IdViaje = rd.GetInt32(0),
                    FechaViaje = rd.GetDateTime(1),
                    Sucursal = rd.GetString(2),
                    Transportista = rd.GetString(3),
                    UsuarioRegistro = rd.GetInt32(4),
                    FechaHoraRegistro = rd.GetDateTime(5)
                });
            }

            return lista;
        }

        // Trip detail

        public List<ViajeDetalleDto> ObtenerDetalle(int idViaje)
        {
            var lista = new List<ViajeDetalleDto>();

            using var cn = _conexionDB.GetConnection();
            cn.Open();

            const string sql = @"
SELECT  ve.IdViajeEmpleado,
        ve.IdEmpleado,
        e.Nombre AS Empleado,
        ve.DistanciaKm,
        ve.TarifaCalculada
FROM dbo.ViajeEmpleado ve
INNER JOIN dbo.Empleados e ON e.IdEmpleado = ve.IdEmpleado
WHERE ve.IdViaje = @IdViaje
ORDER BY e.Nombre;";

            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@IdViaje", idViaje);

            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                lista.Add(new ViajeDetalleDto
                {
                    IdViajeEmpleado = rd.GetInt32(0),
                    IdEmpleado = rd.GetInt32(1),
                    Empleado = rd.GetString(2),
                    DistanciaKm = rd.GetDecimal(3),
                    TarifaCalculada = rd.GetDecimal(4)
                });
            }

            return lista;
        }

        // Pricing helpers

        public decimal ObtenerTarifaPorKmTransportista(int idTransportista)
        {
            using var cn = _conexionDB.GetConnection();
            cn.Open();

            const string sql = @"
SELECT TarifaPorKm
FROM dbo.Transportistas
WHERE IdTransportista = @IdTransportista AND Activo = 1;";

            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@IdTransportista", idTransportista);

            var result = cmd.ExecuteScalar();
            if (result == null)
                throw new Exception("Transportista no existe o está inactivo.");

            return Convert.ToDecimal(result);
        }
    }

    // DTOs / Requests

    public class SucursalDto
    {
        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = "";
    }

    public class TransportistaDto
    {
        public int IdTransportista { get; set; }
        public string Nombre { get; set; } = "";
        public decimal TarifaPorKm { get; set; }
    }

    public class EmpleadoDto
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } = "";
    }

    public class ViajeGuardarRequest
    {
        public DateTime FechaViaje { get; set; }
        public int IdSucursal { get; set; }
        public int IdTransportista { get; set; }
        public int UsuarioRegistro { get; set; }
        public List<ViajeEmpleadoDetalle> Detalle { get; set; } = new();
    }

    public class ViajeEmpleadoDetalle
    {
        public int IdEmpleado { get; set; }
        public decimal DistanciaKm { get; set; }
        public decimal TarifaCalculada { get; set; }
    }

    public class ViajeListadoDto
    {
        public int IdViaje { get; set; }
        public DateTime FechaViaje { get; set; }
        public string Sucursal { get; set; } = "";
        public string Transportista { get; set; } = "";
        public int UsuarioRegistro { get; set; }
        public DateTime FechaHoraRegistro { get; set; }
    }

    public class ViajeDetalleDto
    {
        public int IdViajeEmpleado { get; set; }
        public int IdEmpleado { get; set; }
        public string Empleado { get; set; } = "";
        public decimal DistanciaKm { get; set; }
        public decimal TarifaCalculada { get; set; }
    }
}
