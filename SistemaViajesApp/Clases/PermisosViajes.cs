using System;

namespace SistemaViajesApp
{
    public static class PermisosViajes
    {
        public static bool PuedeIngresar(string rol) => EsAdmin(rol) || EsGerente(rol);
        public static bool PuedeVerListado(string rol) => EsAdmin(rol) || EsGerente(rol);
        public static bool PuedeEditar(string rol) => EsAdmin(rol);
        public static bool PuedeEliminar(string rol) => EsAdmin(rol);

        private static bool EsAdmin(string rol) =>
            string.Equals(rol?.Trim(), "Admin", StringComparison.OrdinalIgnoreCase);

        private static bool EsGerente(string rol) =>
            string.Equals(rol?.Trim(), "Gerente", StringComparison.OrdinalIgnoreCase);
    }
}