namespace SistemaViajesApp
{
    partial class FrmLogs
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
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            cmbModulo = new ComboBox();
            cmbExitoso = new ComboBox();
            label3 = new Label();
            BtnFiltrar = new Button();
            BtnImprimir = new Button();
            BtnExportarExcel = new Button();
            BtnCerrar = new Button();
            dataGridView1 = new DataGridView();
            conexionDBBindingSource = new BindingSource(components);
            cmbUsuario = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)conexionDBBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(89, 28);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(250, 27);
            dtpDesde.TabIndex = 0;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(89, 72);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(250, 27);
            dtpHasta.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 2;
            label1.Text = "Desde";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 77);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 3;
            label2.Text = "Hasta";
            // 
            // cmbModulo
            // 
            cmbModulo.FormattingEnabled = true;
            cmbModulo.Location = new Point(389, 28);
            cmbModulo.Name = "cmbModulo";
            cmbModulo.Size = new Size(271, 28);
            cmbModulo.TabIndex = 4;
            cmbModulo.Text = "Modulo";
            // 
            // cmbExitoso
            // 
            cmbExitoso.FormattingEnabled = true;
            cmbExitoso.Location = new Point(146, 119);
            cmbExitoso.Name = "cmbExitoso";
            cmbExitoso.Size = new Size(250, 28);
            cmbExitoso.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 127);
            label3.Name = "label3";
            label3.Size = new Size(124, 20);
            label3.TabIndex = 7;
            label3.Text = "Tipo transsaccion";
            // 
            // BtnFiltrar
            // 
            BtnFiltrar.Location = new Point(508, 123);
            BtnFiltrar.Name = "BtnFiltrar";
            BtnFiltrar.Size = new Size(94, 29);
            BtnFiltrar.TabIndex = 8;
            BtnFiltrar.Text = "Filtrar";
            BtnFiltrar.UseVisualStyleBackColor = true;
            BtnFiltrar.Click += BtnFiltrar_Click;
            // 
            // BtnImprimir
            // 
            BtnImprimir.Location = new Point(12, 409);
            BtnImprimir.Name = "BtnImprimir";
            BtnImprimir.Size = new Size(94, 29);
            BtnImprimir.TabIndex = 9;
            BtnImprimir.Text = "Imprimir";
            BtnImprimir.UseVisualStyleBackColor = true;
            BtnImprimir.Click += BtnImprimir_Click;
            // 
            // BtnExportarExcel
            // 
            BtnExportarExcel.Location = new Point(124, 409);
            BtnExportarExcel.Name = "BtnExportarExcel";
            BtnExportarExcel.Size = new Size(116, 29);
            BtnExportarExcel.TabIndex = 10;
            BtnExportarExcel.Text = "Exportar .xls";
            BtnExportarExcel.UseVisualStyleBackColor = true;
            BtnExportarExcel.Click += BtnExportarExcel_Click;
            // 
            // BtnCerrar
            // 
            BtnCerrar.Location = new Point(694, 409);
            BtnCerrar.Name = "BtnCerrar";
            BtnCerrar.Size = new Size(94, 29);
            BtnCerrar.TabIndex = 11;
            BtnCerrar.Text = "Salir";
            BtnCerrar.UseVisualStyleBackColor = true;
            BtnCerrar.Click += BtnCerrar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.DataSource = conexionDBBindingSource;
            dataGridView1.Location = new Point(20, 162);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(735, 223);
            dataGridView1.TabIndex = 12;
            // 
            // conexionDBBindingSource
            // 
            conexionDBBindingSource.DataSource = typeof(ConexionDB);
            // 
            // cmbUsuario
            // 
            cmbUsuario.FormattingEnabled = true;
            cmbUsuario.Location = new Point(389, 69);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Size = new Size(271, 28);
            cmbUsuario.TabIndex = 13;
            // 
            // FrmLogs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbUsuario);
            Controls.Add(dataGridView1);
            Controls.Add(BtnCerrar);
            Controls.Add(BtnExportarExcel);
            Controls.Add(BtnImprimir);
            Controls.Add(BtnFiltrar);
            Controls.Add(label3);
            Controls.Add(cmbExitoso);
            Controls.Add(cmbModulo);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Name = "FrmLogs";
            Text = "FrmLogs";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)conexionDBBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Label label1;
        private Label label2;
        private ComboBox cmbModulo;
        private ComboBox cmbExitoso;
        private Label label3;
        private Button BtnFiltrar;
        private Button BtnImprimir;
        private Button BtnExportarExcel;
        private Button BtnCerrar;
        private DataGridView dataGridView1;
        private BindingSource conexionDBBindingSource;
        private ComboBox cmbUsuario;
    }
}