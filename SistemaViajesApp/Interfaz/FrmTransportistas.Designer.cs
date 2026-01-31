namespace SistemaViajesApp
{
    partial class FrmTransportistas
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
            dataGridView1 = new DataGridView();
            conexionDBBindingSource = new BindingSource(components);
            txtNombre = new TextBox();
            BtnNuevo = new Button();
            BtnGuardar = new Button();
            BtnEditar = new Button();
            BtnEliminar = new Button();
            BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)conexionDBBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.DataSource = conexionDBBindingSource;
            dataGridView1.Location = new Point(68, 175);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(663, 188);
            dataGridView1.TabIndex = 0;
            // 
            // conexionDBBindingSource
            // 
            conexionDBBindingSource.DataSource = typeof(SistemaViajesApp.ConexionDB);
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(68, 42);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(240, 27);
            txtNombre.TabIndex = 1;
            // 
            // BtnNuevo
            // 
            BtnNuevo.Location = new Point(68, 126);
            BtnNuevo.Name = "BtnNuevo";
            BtnNuevo.Size = new Size(94, 29);
            BtnNuevo.TabIndex = 2;
            BtnNuevo.Text = "Nuevo";
            BtnNuevo.UseVisualStyleBackColor = true;
            BtnNuevo.Click += BtnNuevo_Click;
            // 
            // BtnGuardar
            // 
            BtnGuardar.Location = new Point(168, 126);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(94, 29);
            BtnGuardar.TabIndex = 3;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.TextAlign = ContentAlignment.BottomCenter;
            BtnGuardar.UseVisualStyleBackColor = true;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // BtnEditar
            // 
            BtnEditar.Location = new Point(268, 126);
            BtnEditar.Name = "BtnEditar";
            BtnEditar.Size = new Size(94, 29);
            BtnEditar.TabIndex = 4;
            BtnEditar.Text = "Editar";
            BtnEditar.UseVisualStyleBackColor = true;
            BtnEditar.Click += BtnEditar_Click;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Location = new Point(368, 126);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(94, 29);
            BtnEliminar.TabIndex = 5;
            BtnEliminar.Text = "Eliminar";
            BtnEliminar.UseVisualStyleBackColor = true;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // BtnCerrar
            // 
            BtnCerrar.Location = new Point(637, 126);
            BtnCerrar.Name = "BtnCerrar";
            BtnCerrar.Size = new Size(94, 29);
            BtnCerrar.TabIndex = 6;
            BtnCerrar.Text = "Cerrar";
            BtnCerrar.UseVisualStyleBackColor = true;
            BtnCerrar.Click += BtnCerrar_Click;
            // 
            // FrmTransportistas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnCerrar);
            Controls.Add(BtnEliminar);
            Controls.Add(BtnEditar);
            Controls.Add(BtnGuardar);
            Controls.Add(BtnNuevo);
            Controls.Add(txtNombre);
            Controls.Add(dataGridView1);
            Name = "FrmTransportistas";
            Text = "FrmTransportistas";
            Load += FrmTransportistas_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)conexionDBBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource conexionDBBindingSource;
        private TextBox txtNombre;
        private Button BtnNuevo;
        private Button BtnGuardar;
        private Button BtnEditar;
        private Button BtnEliminar;
        private Button BtnCerrar;
    }
}