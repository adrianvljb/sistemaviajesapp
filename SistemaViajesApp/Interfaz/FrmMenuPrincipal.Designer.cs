using SistemaViajesApp;

namespace SistemaViajesApp
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            mnuEmpleados = new ToolStripMenuItem();
            mnuTransportistas = new ToolStripMenuItem();
            mnuViajes = new ToolStripMenuItem();
            mnuViajesIngresar = new ToolStripMenuItem();
            mnuViajesListado = new ToolStripMenuItem();
            mnuReportes = new ToolStripMenuItem();
            mnuLogs = new ToolStripMenuItem();
            mnuSalir = new ToolStripMenuItem();
            lblUsuarioRol = new StatusStrip();
            lblUsuario = new ToolStripStatusLabel();
            lblRol = new ToolStripStatusLabel();
            lblFecha = new ToolStripStatusLabel();
            lblHora = new ToolStripStatusLabel();
            conexionDBBindingSource = new BindingSource(components);
            timerHora = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            lblUsuarioRol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)conexionDBBindingSource).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuEmpleados, mnuTransportistas, mnuViajes, mnuReportes, mnuLogs, mnuSalir });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuEmpleados
            // 
            mnuEmpleados.Name = "mnuEmpleados";
            mnuEmpleados.Size = new Size(97, 24);
            mnuEmpleados.Text = "Empleados";
            // 
            // mnuTransportistas
            // 
            mnuTransportistas.Name = "mnuTransportistas";
            mnuTransportistas.Size = new Size(108, 24);
            mnuTransportistas.Text = "Transportista";
            // 
            // mnuViajes
            // 
            mnuViajes.DropDownItems.AddRange(new ToolStripItem[] { mnuViajesIngresar, mnuViajesListado });
            mnuViajes.Name = "mnuViajes";
            mnuViajes.Size = new Size(62, 24);
            mnuViajes.Text = "Viajes";
            // 
            // mnuViajesIngresar
            // 
            mnuViajesIngresar.Name = "mnuViajesIngresar";
            mnuViajesIngresar.Size = new Size(224, 26);
            mnuViajesIngresar.Text = "Ingresar viaje";
            mnuViajesIngresar.Click += mnuViajesIngresar_Click_1;
            // 
            // mnuViajesListado
            // 
            mnuViajesListado.Name = "mnuViajesListado";
            mnuViajesListado.Size = new Size(224, 26);
            mnuViajesListado.Text = "Ver listado de viajes";
            mnuViajesListado.Click += mnuViajesListado_Click_1;
            // 
            // mnuReportes
            // 
            mnuReportes.Name = "mnuReportes";
            mnuReportes.Size = new Size(82, 24);
            mnuReportes.Text = "Reportes";
            
            // 
            // mnuLogs
            // 
            mnuLogs.Name = "mnuLogs";
            mnuLogs.Size = new Size(54, 24);
            mnuLogs.Text = "Logs";
            // 
            // mnuSalir
            // 
            mnuSalir.Name = "mnuSalir";
            mnuSalir.Size = new Size(52, 24);
            mnuSalir.Text = "Salir";
            mnuSalir.Click += mnuSalir_Click_1;
            // 
            // lblUsuarioRol
            // 
            lblUsuarioRol.ImageScalingSize = new Size(20, 20);
            lblUsuarioRol.Items.AddRange(new ToolStripItem[] { lblUsuario, lblRol, lblFecha, lblHora });
            lblUsuarioRol.Location = new Point(0, 428);
            lblUsuarioRol.Name = "lblUsuarioRol";
            lblUsuarioRol.Size = new Size(800, 22);
            lblUsuarioRol.TabIndex = 1;
            lblUsuarioRol.Text = "statusStrip1";
            // 
            // lblUsuario
            // 
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(0, 16);
            // 
            // lblRol
            // 
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(0, 16);
            // 
            // lblFecha
            // 
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(0, 16);
            // 
            // lblHora
            // 
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(0, 16);
            // 
            // conexionDBBindingSource
            // 
            conexionDBBindingSource.DataSource = typeof(ConexionDB);
            // 
            // timerHora
            // 
            timerHora.Enabled = true;
            timerHora.Interval = 1000;
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblUsuarioRol);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMenuPrincipal";
            Text = "FrmMenuPrincipal";
            Load += FrmMenuPrincipal_Load_1;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            lblUsuarioRol.ResumeLayout(false);
            lblUsuarioRol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)conexionDBBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuEmpleados;
        private ToolStripMenuItem mnuTransportistas;
        private ToolStripMenuItem mnuViajes;
        private ToolStripMenuItem mnuReportes;
        private ToolStripMenuItem mnuLogs;
        private ToolStripMenuItem mnuSalir;
        private StatusStrip lblUsuarioRol;
        private BindingSource conexionDBBindingSource;
        private ToolStripMenuItem mnuViajesIngresar;
        private ToolStripMenuItem mnuViajesListado;
        private ToolStripStatusLabel lblUsuario;
        private ToolStripStatusLabel lblRol;
        private ToolStripStatusLabel lblFecha;
        private ToolStripStatusLabel lblHora;
        private System.Windows.Forms.Timer timerHora;
    }
}