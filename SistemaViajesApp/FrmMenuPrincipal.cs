using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaViajesApp
{
    public partial class FrmMenuPrincipal : Form
    {
        private Panel pnlMenu = new Panel();
        private Label lblUsuarioRol = new Label();

        private Button btnEmpleados = new Button();
        private Button btnViajes = new Button();
        private Button btnTransportistas = new Button();
        private Button btnUsuarios = new Button();
        private Button btnReportes = new Button();
        private Button btnCerrarSesion = new Button();

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            ConstruirUI();
            AplicarPermisosPorRol();
        }

        private void ConstruirUI()
        {
            this.IsMdiContainer = true;
            this.Text = "SistemaViajesApp - Menú Principal";
            this.WindowState = FormWindowState.Maximized;

            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Width = 230;
            pnlMenu.BackColor = Color.Gainsboro;
            this.Controls.Add(pnlMenu);

            lblUsuarioRol.AutoSize = false;
            lblUsuarioRol.Dock = DockStyle.Top;
            lblUsuarioRol.Height = 70;
            lblUsuarioRol.TextAlign = ContentAlignment.MiddleLeft;
            lblUsuarioRol.Padding = new Padding(10, 10, 10, 10);
            lblUsuarioRol.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblUsuarioRol.Text = $"Usuario: {Sesion.Usuario}\nRol: {Sesion.Rol}";
            pnlMenu.Controls.Add(lblUsuarioRol);

            ConfigBtn(btnEmpleados, "Empleados", 80, (_, __) => AbrirHijo(new FrmEmpleados()));
            ConfigBtn(btnViajes, "Viajes", 125, (_, __) => AbrirHijo(new FrmViajes()));
            ConfigBtn(btnTransportistas, "Transportistas", 170, (_, __) => AbrirHijo(new FrmTransportistas()));
            ConfigBtn(btnUsuarios, "Usuarios", 215, (_, __) => AbrirHijo(new FrmUsuarios()));
            ConfigBtn(btnReportes, "Reportes", 260, (_, __) => AbrirHijo(new FrmReportes()));
            ConfigBtn(btnCerrarSesion, "Cerrar sesión", 315, (_, __) => CerrarSesion());
        }

        private void ConfigBtn(Button b, string text, int top, EventHandler onClick)
        {
            b.Text = text;
            b.Left = 10;
            b.Top = top;
            b.Width = 210;
            b.Height = 40;
            b.Click += onClick;
            pnlMenu.Controls.Add(b);
        }

        private void AbrirHijo(Form frm)
        {
            // Evitar múltiples instancias del mismo form (por tipo)
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

        private void AplicarPermisosPorRol()
        {
            string rol = (Sesion.Rol ?? "").Trim().ToLowerInvariant();

            // Ajusta reglas según tus roles reales:
            // admin: todo
            // gerente: todo menos usuarios
            // transportista: solo viajes y reportes (ejemplo)
            if (rol == "admin")
            {
                // todo habilitado
            }
            else if (rol == "gerente")
            {
                btnUsuarios.Enabled = false;
            }
            else if (rol == "transportista")
            {
                btnEmpleados.Enabled = false;
                btnTransportistas.Enabled = false;
                btnUsuarios.Enabled = false;
                btnViajes.Enabled = true;
                btnReportes.Enabled = true;
            }
            else
            {
                // rol no reconocido -> mínimo acceso
                btnEmpleados.Enabled = false;
                btnTransportistas.Enabled = false;
                btnUsuarios.Enabled = false;
            }
