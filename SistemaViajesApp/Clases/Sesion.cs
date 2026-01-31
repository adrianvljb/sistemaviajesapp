namespace SistemaViajesApp
{
    public static class Sesion
    {
        public static string Usuario { get; set; }
        public static string Rol { get; set; }

        public static void Cerrar()
        {
            Usuario = null;
            Rol = null;
        }
    }
}