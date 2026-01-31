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
            Load += FrmMenuPrincipal_Load;
        }

        private void FrmMenuPrincipal_Load(object? sender, EventArgs e)
        {
            IsMdiContainer = true;

            PermisosUI.AplicarPermisos(
                Sesion.Rol,
                mnuEmpleados,
                mnuTransportistas,
                mnuViajes,
                mnuReportes,
                mnuLogs,
                mnuSalir
            );

            lblUsuario.Text = $"Usuario: {Sesion.Usuario}";
            lblRol.Text = $"Rol: {Sesion.Rol}";
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            timerHora.Interval = 1000;
            timerHora.Tick += TimerHora_Tick;
            timerHora.Start();

            WireMenuEvents();
        }

        private void WireMenuEvents()
        {
            mnuEmpleados.Click -= mnuEmpleados_Click;
            mnuEmpleados.Click += mnuEmpleados_Click;

            mnuTransportistas.Click -= mnuTransportistas_Click;
            mnuTransportistas.Click += mnuTransportistas_Click;

            mnuReportes.Click -= mnuReportes_Click;
            mnuReportes.Click += mnuReportes_Click;

            mnuLogs.Click -= mnuLogs_Click;
            mnuLogs.Click += mnuLogs_Click;
        }

        private void TimerHora_Tick(object? sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void mnuEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmEmpleados());
        }

        private void mnuTransportistas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmTransportistas());
        }

        private void mnuReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmPagoMotorista());
        }

        private void mnuLogs_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmLogs());
        }

        private void mnuViajesIngresar_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmViajesIngreso());
        }

        private void mnuViajesListado_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmViajesListado());
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            timerHora.Stop();
            Sesion.Cerrar();
            Hide();
            new LoginForm().Show();
        }

        private void AbrirFormulario(Form frm)
        {
            foreach (Form f in MdiChildren)
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

        private void mnuViajesIngresar_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmViajesIngreso());
        }

        private void mnuViajesListado_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmViajesListado());
        }

        private void mnuSalir_Click_1(object sender, EventArgs e)
        {
            mnuSalir_Click(sender, e);
        }

        private void FrmMenuPrincipal_Load_1(object sender, EventArgs e)
        {
            FrmMenuPrincipal_Load(sender, e);
        }

        
    }

   
}
