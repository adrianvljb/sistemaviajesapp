using System;
using System.Windows.Forms;

namespace SistemaViajesApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var login = new LoginForm())
            {
                if (login.ShowDialog() != DialogResult.OK)
                    return; // si falla o cancela, cerrar app
            }

            Application.Run(new FrmMenuPrincipal());
        }
    }
}