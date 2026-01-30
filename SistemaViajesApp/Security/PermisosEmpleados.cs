using System;

namespace SistemaViajesApp
{
    public static class PermisosEmpleados
    {
        public static bool PuedeVer(string rol) => EsAdmin(rol);

        public static bool PuedeCrear(string rol) => EsAdmin(rol);

        public static bool PuedeEditar(string rol) => EsAdmin(rol);

        public static bool PuedeEliminar(string rol) => EsAdmin(rol);

        private static bool EsAdmin(string rol) =>
            string.Equals(rol?.Trim(), "Admin", StringComparison.OrdinalIgnoreCase);
    }
}
