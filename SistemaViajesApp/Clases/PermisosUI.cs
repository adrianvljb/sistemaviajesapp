using System.Windows.Forms;

namespace SistemaViajesApp
{
    public static class PermisosUI
    {
        public static void AplicarPermisos(
            string rol,
            ToolStripMenuItem mnuEmpleados,
            ToolStripMenuItem mnuTransportistas,
            ToolStripMenuItem mnuViajes,
            ToolStripMenuItem mnuReportes,
            ToolStripMenuItem mnuLogs,
            ToolStripMenuItem mnuSalir
        )
        {
            // Por defecto: todo deshabilitado
            mnuEmpleados.Enabled = false;
            mnuTransportistas.Enabled = false;
            mnuViajes.Enabled = false;
            mnuReportes.Enabled = false;
            mnuLogs.Enabled = false;
            mnuSalir.Enabled = true; // siempre

            rol = (rol ?? "").Trim().ToLower();

            switch (rol)
            {
                case "admin":
                    mnuEmpleados.Enabled = true;
                    mnuTransportistas.Enabled = true;
                    mnuViajes.Enabled = true;
                    mnuReportes.Enabled = true;
                    mnuLogs.Enabled = true;
                    break;

                case "gerente":
                    mnuEmpleados.Enabled = true;
                    mnuTransportistas.Enabled = true;
                    mnuViajes.Enabled = true;
                    mnuReportes.Enabled = true;
                    // Logs NO
                    break;

                default:
                    // Rol no autorizado → solo salir
                    break;
            }
        }
    }
}
