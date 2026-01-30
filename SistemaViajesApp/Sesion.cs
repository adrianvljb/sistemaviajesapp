namespace SistemaViajesApp
{
    public static class Sesion
    {
        public static string Usuario { get; set; } = string.Empty;
        public static string Rol { get; set; } = string.Empty;

        // Método opcional para limpiar sesión al cerrar sesión
        public static void Limpiar()
        {
            Usuario = string.Empty;
            Rol = string.Empty;
        }
    }
}