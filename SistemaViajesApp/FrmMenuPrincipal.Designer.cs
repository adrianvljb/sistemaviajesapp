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
            menuStrip1 = new MenuStrip();
            mnuEmpleados = new ToolStripMenuItem();
            mnuTransportistas = new ToolStripMenuItem();
            mnuViajes = new ToolStripMenuItem();
            mnuReportes = new ToolStripMenuItem();
            mnuLogs = new ToolStripMenuItem();
            mnuSalir = new ToolStripMenuItem();
            lblUsuarioRol = new StatusStrip();
            menuStrip1.SuspendLayout();
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
            mnuViajes.Name = "mnuViajes";
            mnuViajes.Size = new Size(62, 24);
            mnuViajes.Text = "Viajes";
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
            // 
            // lblUsuarioRol
            // 
            lblUsuarioRol.ImageScalingSize = new Size(20, 20);
            lblUsuarioRol.Location = new Point(0, 428);
            lblUsuarioRol.Name = "lblUsuarioRol";
            lblUsuarioRol.Size = new Size(800, 22);
            lblUsuarioRol.TabIndex = 1;
            lblUsuarioRol.Text = "statusStrip1";
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
    }
}