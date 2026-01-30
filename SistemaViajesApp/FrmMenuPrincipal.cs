using System;
using System.Windows.Forms;
using SistemaViajesApp.Security;

namespace SistemaViajesApp
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
            this.Load += FrmMenuPrincipal_Load;
        }

        private void FrmMenuPrincipal_Load(object? sender, EventArgs e)
        {
            // Asegurar MDI
            this.IsMdiContainer = true;

            // Mostrar usuario y rol (si usas StatusStrip)
            if (lblUsuarioRol != null)
            {
                lblUsuarioRol.Text = $"Usuario: {Sesion.Usuario} | Rol: {Sesion.Rol}";
            }

            // Aplicar permisos al menú
            PermisosUI.AplicarPermisos(
                Sesion.Rol,
                mnuEmpleados,
                mnuTransportistas,
                mnuViajes,
                mnuReportes,
                mnuLogs,
                mnuSalir
            );
        }

        // ==========================
        // EVENTOS DE MENÚ
        // ==========================

        private void mnuEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmEmpleados());
        }

        private void mnuTransportistas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmTransportistas());
        }

        private void mnuViajes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmViajes());
        }

        private void mnuReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmReportes());
        }

        private void mnuLogs_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmLogs());
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Sesion.Cerrar();
            Hide();
            new LoginForm().Show();
        }

        // ==========================
        // MÉTODO CENTRAL PARA ABRIR FORMS (MDI)
        // ==========================
        private void AbrirFormulario(Form frm)
        {
            // Evitar abrir el mismo form dos veces
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == frm.GetType())
                {
                    f.Activate();
                    return;
                }
            }

            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void FrmMenuPrincipal_Load_1(object sender, EventArgs e)
        {
            mnuEmpleados.Click += mnuEmpleados_Click;
            mnuTransportistas.Click += mnuTransportistas_Click;
            mnuViajes.Click += mnuViajes_Click;
            mnuReportes.Click += mnuReportes_Click;
            mnuLogs.Click += mnuLogs_Click;
            mnuSalir.Click += mnuSalir_Click;

            // MDI
            this.IsMdiContainer = true;
        }

        private void mnuSalir_Click_1(object sender, EventArgs e)
        {

        }
    }
}