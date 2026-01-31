
namespace SistemaViajesApp
{
    partial class FrmViajesIngreso
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
            cmbSucursal = new ComboBox();
            cmbTransportista = new ComboBox();
            dtpFechaViaje = new DateTimePicker();
            BtnGuardar = new Button();
            BtnCerrar = new Button();
            dataGridView1 = new DataGridView();
            conexionDBBindingSource = new BindingSource(components);
            cmbEmpleado = new ComboBox();
            txtDistanciaKm = new TextBox();
            BtnAgregarEmpleado = new Button();
            BtnQuitarEmpleado = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)conexionDBBindingSource).BeginInit();
            SuspendLayout();
            // 
            // cmbSucursal
            // 
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(12, 29);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(194, 28);
            cmbSucursal.TabIndex = 0;
            cmbSucursal.Text = "Sucursal";
            cmbSucursal.SelectedIndexChanged += cmbSucursal_SelectedIndexChanged;
            // 
            // cmbTransportista
            // 
            cmbTransportista.FormattingEnabled = true;
            cmbTransportista.Location = new Point(212, 28);
            cmbTransportista.Name = "cmbTransportista";
            cmbTransportista.Size = new Size(312, 28);
            cmbTransportista.TabIndex = 1;
            cmbTransportista.Text = "Transportista";
            cmbTransportista.SelectedIndexChanged += cmbTransportista_SelectedIndexChanged;
            // 
            // dtpFechaViaje
            // 
            dtpFechaViaje.Location = new Point(530, 29);
            dtpFechaViaje.Name = "dtpFechaViaje";
            dtpFechaViaje.Size = new Size(267, 27);
            dtpFechaViaje.TabIndex = 2;
            dtpFechaViaje.ValueChanged += dtpFecha_ValueChanged;
            // 
            // BtnGuardar
            // 
            BtnGuardar.Location = new Point(556, 378);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(108, 47);
            BtnGuardar.TabIndex = 3;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.UseVisualStyleBackColor = true;
            BtnGuardar.Click += BtnGuardar_Click_1;
            // 
            // BtnCerrar
            // 
            BtnCerrar.Location = new Point(670, 378);
            BtnCerrar.Name = "BtnCerrar";
            BtnCerrar.Size = new Size(118, 47);
            BtnCerrar.TabIndex = 4;
            BtnCerrar.Text = "Cerrar";
            BtnCerrar.UseVisualStyleBackColor = true;
            BtnCerrar.Click += BtnCerrar_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.DataSource = conexionDBBindingSource;
            dataGridView1.Location = new Point(26, 84);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(762, 261);
            dataGridView1.TabIndex = 5;
            // 
            // conexionDBBindingSource
            // 
            conexionDBBindingSource.DataSource = typeof(ConexionDB);
            // 
            // cmbEmpleado
            // 
            cmbEmpleado.FormattingEnabled = true;
            cmbEmpleado.Location = new Point(26, 352);
            cmbEmpleado.Name = "cmbEmpleado";
            cmbEmpleado.Size = new Size(217, 28);
            cmbEmpleado.TabIndex = 6;
            cmbEmpleado.Text = "Empleado";
            cmbEmpleado.SelectedIndexChanged += cmbEmpleado_SelectedIndexChanged;
            // 
            // txtDistanciaKm
            // 
            txtDistanciaKm.Location = new Point(249, 352);
            txtDistanciaKm.Name = "txtDistanciaKm";
            txtDistanciaKm.Size = new Size(143, 27);
            txtDistanciaKm.TabIndex = 7;
            txtDistanciaKm.Text = "Km";
            txtDistanciaKm.TextChanged += txtDistanciaKm_TextChanged;
            // 
            // BtnAgregarEmpleado
            // 
            BtnAgregarEmpleado.Location = new Point(26, 396);
            BtnAgregarEmpleado.Name = "BtnAgregarEmpleado";
            BtnAgregarEmpleado.Size = new Size(156, 29);
            BtnAgregarEmpleado.TabIndex = 8;
            BtnAgregarEmpleado.Text = "Agregar empleado";
            BtnAgregarEmpleado.UseVisualStyleBackColor = true;
            BtnAgregarEmpleado.Click += BtnAgregarEmpleado_Click;
            // 
            // BtnQuitarEmpleado
            // 
            BtnQuitarEmpleado.Location = new Point(188, 396);
            BtnQuitarEmpleado.Name = "BtnQuitarEmpleado";
            BtnQuitarEmpleado.Size = new Size(156, 29);
            BtnQuitarEmpleado.TabIndex = 9;
            BtnQuitarEmpleado.Text = "Quitar empleado";
            BtnQuitarEmpleado.UseVisualStyleBackColor = true;
            BtnQuitarEmpleado.Click += BtnQuitarEmpleado_Click;
            // 
            // FrmViajesIngreso
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnQuitarEmpleado);
            Controls.Add(BtnAgregarEmpleado);
            Controls.Add(txtDistanciaKm);
            Controls.Add(cmbEmpleado);
            Controls.Add(dataGridView1);
            Controls.Add(BtnCerrar);
            Controls.Add(BtnGuardar);
            Controls.Add(dtpFechaViaje);
            Controls.Add(cmbTransportista);
            Controls.Add(cmbSucursal);
            Name = "FrmViajesIngreso";
            Text = "FrmViajesIngreso";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)conexionDBBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

       
        #endregion

        private ComboBox cmbSucursal;
        private ComboBox cmbTransportista;
        private DateTimePicker dtpFechaViaje;
        private Button BtnGuardar;
        private Button BtnCerrar;
        private DataGridView dataGridView1;
        private BindingSource conexionDBBindingSource;
        private ComboBox cmbEmpleado;
        private TextBox txtDistanciaKm;
        private Button BtnAgregarEmpleado;
        private Button BtnQuitarEmpleado;
    }
}