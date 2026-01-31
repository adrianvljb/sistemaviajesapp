using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace SistemaViajesApp.Services
{
    public class ReportesService
    {
        public DataTable ReportePagoMotorista(DateTime desde, DateTime hasta, int idTransportista, int? idSucursal)
        {
            using var cn = new ConexionDB().GetConnection();
            cn.Open();

            const string sql = @"
SELECT
    v.IdViaje,
    v.FechaViaje,
    s.Nombre AS Sucursal,
    t.Nombre AS Transportista,
    COUNT(ve.IdEmpleado) AS Empleados,
    SUM(ve.DistanciaKm) AS TotalKm,
    SUM(ve.TarifaCalculada) AS TotalPagar
FROM dbo.Viajes v
INNER JOIN dbo.Sucursales s ON s.IdSucursal = v.IdSucursal
INNER JOIN dbo.Transportistas t ON t.IdTransportista = v.IdTransportista
INNER JOIN dbo.ViajeEmpleado ve ON ve.IdViaje = v.IdViaje
WHERE v.FechaViaje >= @Desde
  AND v.FechaViaje <= @Hasta
  AND v.IdTransportista = @IdTransportista
  AND (@IdSucursal IS NULL OR v.IdSucursal = @IdSucursal)
GROUP BY
    v.IdViaje, v.FechaViaje, s.Nombre, t.Nombre
ORDER BY v.FechaViaje ASC, v.IdViaje ASC;";

            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Desde", desde.Date);
            cmd.Parameters.AddWithValue("@Hasta", hasta.Date);
            cmd.Parameters.AddWithValue("@IdTransportista", idTransportista);
            cmd.Parameters.AddWithValue("@IdSucursal", (object?)idSucursal ?? DBNull.Value);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}