namespace SistemaViajesApp
{
    partial class FrmViajesListado
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
            dataGridView1 = new DataGridView();
            cmbSucursal = new ComboBox();
            cmbTransportista = new ComboBox();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            BtnCerrar = new Button();
            BtnFiltrar = new Button();
            dataGridView2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 122);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(389, 259);
            dataGridView1.TabIndex = 0;
            // 
            // cmbSucursal
            // 
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(12, 12);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(250, 28);
            cmbSucursal.TabIndex = 1;
            cmbSucursal.Text = "Sucursal";
            cmbSucursal.SelectedIndexChanged += cmbSucursal_SelectedIndexChanged;
            // 
            // cmbTransportista
            // 
            cmbTransportista.FormattingEnabled = true;
            cmbTransportista.Location = new Point(289, 12);
            cmbTransportista.Name = "cmbTransportista";
            cmbTransportista.Size = new Size(250, 28);
            cmbTransportista.TabIndex = 2;
            cmbTransportista.Text = "Transportista";
            cmbTransportista.SelectedIndexChanged += cmbTransportista_SelectedIndexChanged;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(289, 78);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(250, 27);
            dtpHasta.TabIndex = 3;
            dtpHasta.ValueChanged += dtpHasta_ValueChanged;
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(12, 78);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(250, 27);
            dtpDesde.TabIndex = 4;
            dtpDesde.Tag = "";
            dtpDesde.ValueChanged += dtpDesde_ValueChanged;
            // 
            // BtnCerrar
            // 
            BtnCerrar.Location = new Point(685, 409);
            BtnCerrar.Name = "BtnCerrar";
            BtnCerrar.Size = new Size(94, 29);
            BtnCerrar.TabIndex = 5;
            BtnCerrar.Text = "Cerrar";
            BtnCerrar.UseVisualStyleBackColor = true;
            BtnCerrar.Click += BtnCerrar_Click;
            // 
            // BtnFiltrar
            // 
            BtnFiltrar.Location = new Point(569, 79);
            BtnFiltrar.Name = "BtnFiltrar";
            BtnFiltrar.Size = new Size(94, 29);
            BtnFiltrar.TabIndex = 6;
            BtnFiltrar.Text = "Filtrar";
            BtnFiltrar.UseVisualStyleBackColor = true;
            BtnFiltrar.Click += BtnFiltrar_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(399, 122);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(389, 259);
            dataGridView2.TabIndex = 7;
            // 
            // FrmViajesListado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView2);
            Controls.Add(BtnFiltrar);
            Controls.Add(BtnCerrar);
            Controls.Add(dtpDesde);
            Controls.Add(dtpHasta);
            Controls.Add(cmbTransportista);
            Controls.Add(cmbSucursal);
            Controls.Add(dataGridView1);
            Name = "FrmViajesListado";
            Text = "FrmViajesListado";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox cmbSucursal;
        private ComboBox cmbTransportista;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private Button BtnCerrar;
        private Button BtnFiltrar;
        private DataGridView dataGridView2;
    }
}