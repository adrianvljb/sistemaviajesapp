using SistemaViajesApp;

namespace SistemaViajesApp
{
    partial class FrmEmpleados
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
            BtnNuevo = new Button();
            BtnGuardar = new Button();
            BtnEditar = new Button();
            BtnEliminar = new Button();
            BtnCerrar = new Button();
            dataGridView1 = new DataGridView();
            conexionDBBindingSource = new BindingSource(components);
            txtNombre = new TextBox();
            cmbSucursal = new ComboBox();
            txtDistancia = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)conexionDBBindingSource).BeginInit();
            SuspendLayout();
            // 
            // BtnNuevo
            // 
            BtnNuevo.Location = new Point(25, 39);
            BtnNuevo.Name = "BtnNuevo";
            BtnNuevo.Size = new Size(94, 29);
            BtnNuevo.TabIndex = 0;
            BtnNuevo.Text = "Nuevo";
            BtnNuevo.UseVisualStyleBackColor = true;
            BtnNuevo.Click += BtnNuevo_Click_1;
            // 
            // BtnGuardar
            // 
            BtnGuardar.Location = new Point(125, 39);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(94, 29);
            BtnGuardar.TabIndex = 1;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.UseVisualStyleBackColor = true;
            BtnGuardar.Click += BtnGuardar_Click_1;
            // 
            // BtnEditar
            // 
            BtnEditar.Location = new Point(225, 39);
            BtnEditar.Name = "BtnEditar";
            BtnEditar.Size = new Size(94, 29);
            BtnEditar.TabIndex = 2;
            BtnEditar.Text = "Editar";
            BtnEditar.UseVisualStyleBackColor = true;
            BtnEditar.Click += BtnEditar_Click_1;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Location = new Point(325, 39);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(94, 29);
            BtnEliminar.TabIndex = 3;
            BtnEliminar.Text = "Eliminar";
            BtnEliminar.UseVisualStyleBackColor = true;
            BtnEliminar.Click += BtnEliminar_Click_1;
            // 
            // BtnCerrar
            // 
            BtnCerrar.Location = new Point(694, 39);
            BtnCerrar.Name = "BtnCerrar";
            BtnCerrar.Size = new Size(94, 29);
            BtnCerrar.TabIndex = 4;
            BtnCerrar.Text = "Cerrar";
            BtnCerrar.UseVisualStyleBackColor = true;
            BtnCerrar.Click += BtnCerrar_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = SystemColors.ControlLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.DataSource = conexionDBBindingSource;
            dataGridView1.Location = new Point(12, 151);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(763, 226);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // conexionDBBindingSource
            // 
            conexionDBBindingSource.DataSource = typeof(ConexionDB);
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(25, 91);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(246, 27);
            txtNombre.TabIndex = 6;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // cmbSucursal
            // 
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(277, 91);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(263, 28);
            cmbSucursal.TabIndex = 7;
            cmbSucursal.SelectedIndexChanged += cmbSucursal_SelectedIndexChanged;
            // 
            // txtDistancia
            // 
            txtDistancia.Location = new Point(550, 91);
            txtDistancia.Name = "txtDistancia";
            txtDistancia.Size = new Size(238, 27);
            txtDistancia.TabIndex = 8;
            txtDistancia.TextChanged += txtDistancia_TextChanged;
            // 
            // FrmEmpleados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtDistancia);
            Controls.Add(cmbSucursal);
            Controls.Add(txtNombre);
            Controls.Add(dataGridView1);
            Controls.Add(BtnCerrar);
            Controls.Add(BtnEliminar);
            Controls.Add(BtnEditar);
            Controls.Add(BtnGuardar);
            Controls.Add(BtnNuevo);
            Name = "FrmEmpleados";
            Text = "FrmEmpleados";
            Load += FrmEmpleados_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)conexionDBBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnNuevo;
        private Button BtnGuardar;
        private Button BtnEditar;
        private Button BtnEliminar;
        private Button BtnCerrar;
        private DataGridView dataGridView1;
        private BindingSource conexionDBBindingSource;
        private TextBox txtNombre;
        private ComboBox cmbSucursal;
        private TextBox txtDistancia;
    }
}