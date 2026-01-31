using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaViajesApp
{
    partial class FrmPagoMotorista
    {
        private IContainer components = null;

        private ComboBox cmbTransportista;
        private ComboBox cmbSucursal;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Label labelDesde;
        private Label labelHasta;
        private Button BtnFiltrar;
        private Button BtnImprimir;
        private Button BtnExportarExcel;
        private Button BtnCerrar;
        private DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbTransportista = new ComboBox();
            cmbSucursal = new ComboBox();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            labelDesde = new Label();
            labelHasta = new Label();
            BtnFiltrar = new Button();
            BtnImprimir = new Button();
            BtnExportarExcel = new Button();
            BtnCerrar = new Button();
            dataGridView1 = new DataGridView();
            ((ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // cmbTransportista
            // 
            cmbTransportista.FormattingEnabled = true;
            cmbTransportista.Location = new Point(12, 12);
            cmbTransportista.Name = "cmbTransportista";
            cmbTransportista.Size = new Size(260, 28);
            cmbTransportista.TabIndex = 0;
            cmbTransportista.Text = "Transportista";
            // 
            // cmbSucursal
            // 
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(12, 46);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(260, 28);
            cmbSucursal.TabIndex = 1;
            cmbSucursal.Text = "Sucursal";
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(350, 12);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(260, 27);
            dtpDesde.TabIndex = 3;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(350, 46);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(260, 27);
            dtpHasta.TabIndex = 5;
            // 
            // labelDesde
            // 
            labelDesde.AutoSize = true;
            labelDesde.Location = new Point(290, 16);
            labelDesde.Name = "labelDesde";
            labelDesde.Size = new Size(51, 20);
            labelDesde.TabIndex = 2;
            labelDesde.Text = "Desde";
            // 
            // labelHasta
            // 
            labelHasta.AutoSize = true;
            labelHasta.Location = new Point(294, 50);
            labelHasta.Name = "labelHasta";
            labelHasta.Size = new Size(47, 20);
            labelHasta.TabIndex = 4;
            labelHasta.Text = "Hasta";
            // 
            // BtnFiltrar
            // 
            BtnFiltrar.Location = new Point(630, 29);
            BtnFiltrar.Name = "BtnFiltrar";
            BtnFiltrar.Size = new Size(110, 29);
            BtnFiltrar.TabIndex = 6;
            BtnFiltrar.Text = "Filtrar";
            BtnFiltrar.UseVisualStyleBackColor = true;
            // 
            // BtnImprimir
            // 
            BtnImprimir.Location = new Point(12, 409);
            BtnImprimir.Name = "BtnImprimir";
            BtnImprimir.Size = new Size(94, 29);
            BtnImprimir.TabIndex = 8;
            BtnImprimir.Text = "Imprimir";
            BtnImprimir.UseVisualStyleBackColor = true;
            // 
            // BtnExportarExcel
            // 
            BtnExportarExcel.Location = new Point(112, 409);
            BtnExportarExcel.Name = "BtnExportarExcel";
            BtnExportarExcel.Size = new Size(130, 29);
            BtnExportarExcel.TabIndex = 9;
            BtnExportarExcel.Text = "Exportar .xls";
            BtnExportarExcel.UseVisualStyleBackColor = true;
            // 
            // BtnCerrar
            // 
            BtnCerrar.Location = new Point(694, 409);
            BtnCerrar.Name = "BtnCerrar";
            BtnCerrar.Size = new Size(94, 29);
            BtnCerrar.TabIndex = 10;
            BtnCerrar.Text = "Cerrar";
            BtnCerrar.UseVisualStyleBackColor = true;
            BtnCerrar.Click += BtnCerrar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 92);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 300);
            dataGridView1.TabIndex = 7;
            // 
            // FrmPagoMotorista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnCerrar);
            Controls.Add(BtnExportarExcel);
            Controls.Add(BtnImprimir);
            Controls.Add(dataGridView1);
            Controls.Add(BtnFiltrar);
            Controls.Add(dtpHasta);
            Controls.Add(labelHasta);
            Controls.Add(dtpDesde);
            Controls.Add(labelDesde);
            Controls.Add(cmbSucursal);
            Controls.Add(cmbTransportista);
            Name = "FrmPagoMotorista";
            Text = "Pago a motorista";
            ((ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}