using SistemaViajesApp.Services;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaViajesApp
{
    public partial class FrmPagoMotorista : Form
    {
        private readonly ViajesService _catalogos = new ViajesService();
        private readonly ReportesService _reportes = new ReportesService();

        private DataTable _data = new DataTable();

        private readonly PrintDocument _printDoc = new PrintDocument();
        private int _printRowIndex;
        private int _printPageNumber;

        public FrmPagoMotorista()
        {
            InitializeComponent();

            WireEvents();
            ConfigureGrid();
            LoadCatalogs();
            InitDates();

            Shown += FrmPagoMotorista_Shown;

            _printDoc.BeginPrint += PrintDoc_BeginPrint;
            _printDoc.PrintPage += PrintDoc_PrintPage;
        }

        private void WireEvents()
        {
            BtnFiltrar.Click += BtnFiltrar_Click;
            BtnImprimir.Click += BtnImprimir_Click;
            BtnExportarExcel.Click += BtnExportarExcel_Click;
            BtnCerrar.Click += BtnCerrar_Click;

            dtpDesde.ValueChanged += dtpDesde_ValueChanged;
            dtpHasta.ValueChanged += dtpHasta_ValueChanged;
        }

        private void ConfigureGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadCatalogs()
        {
            cmbTransportista.DisplayMember = "Nombre";
            cmbTransportista.ValueMember = "IdTransportista";
            cmbTransportista.DataSource = _catalogos.GetTransportistas();
            cmbTransportista.SelectedIndex = -1;

            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "IdSucursal";
            cmbSucursal.DataSource = _catalogos.GetSucursales();
            cmbSucursal.SelectedIndex = -1;
        }

        private void InitDates()
        {
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;
        }

        private void FrmPagoMotorista_Shown(object? sender, EventArgs e)
        {
            if (cmbTransportista.Items.Count > 0 && cmbTransportista.SelectedIndex < 0)
                cmbTransportista.SelectedIndex = 0;

            TryLoadReport();
        }

        private void TryLoadReport()
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadReport()
        {
            if (cmbTransportista.SelectedValue == null)
                throw new InvalidOperationException("Seleccione un transportista.");

            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            if (desde > hasta)
                throw new InvalidOperationException("El rango de fechas no es válido.");

            int idTransportista = Convert.ToInt32(cmbTransportista.SelectedValue);
            int? idSucursal = GetSelectedInt(cmbSucursal);

            _data = _reportes.ReportePagoMotorista(desde, hasta, idTransportista, idSucursal);
            AddTotalsRow(_data);

            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _data;

            FormatColumns();
        }

        private static int? GetSelectedInt(ComboBox combo)
        {
            if (combo.SelectedIndex < 0 || combo.SelectedValue == null)
                return null;

            return Convert.ToInt32(combo.SelectedValue);
        }

        private static void AddTotalsRow(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return;

            if (!dt.Columns.Contains("Sucursal") || !dt.Columns.Contains("TotalKm") || !dt.Columns.Contains("TotalPagar"))
                return;

            decimal totalKm = 0m;
            decimal totalPagar = 0m;

            foreach (DataRow row in dt.Rows)
            {
                totalKm += row["TotalKm"] == DBNull.Value ? 0m : Convert.ToDecimal(row["TotalKm"], CultureInfo.InvariantCulture);
                totalPagar += row["TotalPagar"] == DBNull.Value ? 0m : Convert.ToDecimal(row["TotalPagar"], CultureInfo.InvariantCulture);
            }

            DataRow totalRow = dt.NewRow();
            totalRow["Sucursal"] = "TOTAL";
            totalRow["TotalKm"] = totalKm;
            totalRow["TotalPagar"] = totalPagar;
            dt.Rows.Add(totalRow);
        }

        private void FormatColumns()
        {
            if (dataGridView1.Columns["FechaViaje"] != null)
                dataGridView1.Columns["FechaViaje"].DefaultCellStyle.Format = "yyyy-MM-dd";

            if (dataGridView1.Columns["TotalKm"] != null)
                dataGridView1.Columns["TotalKm"].DefaultCellStyle.Format = "N2";

            if (dataGridView1.Columns["TotalPagar"] != null)
                dataGridView1.Columns["TotalPagar"].DefaultCellStyle.Format = "N2";
        }

        private void ExportToXlsHtml()
        {
            if (_data.Rows.Count == 0)
                throw new InvalidOperationException("No hay datos para exportar.");

            using var sfd = new SaveFileDialog
            {
                Filter = "Excel (*.xls)|*.xls",
                FileName = $"PagoMotorista_{DateTime.Now:yyyyMMdd_HHmm}.xls"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            string html = BuildHtmlTable(_data, "Reporte de Pago a Motorista");
            File.WriteAllText(sfd.FileName, html, Encoding.UTF8);
        }

        private static string BuildHtmlTable(DataTable dt, string title)
        {
            var sb = new StringBuilder();

            sb.AppendLine("<html><head><meta charset=\"utf-8\" /></head><body>");
            sb.AppendLine($"<h3>{System.Security.SecurityElement.Escape(title)}</h3>");
            sb.AppendLine("<table border=\"1\" cellspacing=\"0\" cellpadding=\"4\">");

            sb.AppendLine("<tr>");
            foreach (DataColumn col in dt.Columns)
            {
                sb.Append("<th>");
                sb.Append(System.Security.SecurityElement.Escape(col.ColumnName));
                sb.AppendLine("</th>");
            }
            sb.AppendLine("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine("<tr>");
                foreach (DataColumn col in dt.Columns)
                {
                    string value = row[col] == DBNull.Value ? "" : Convert.ToString(row[col], CultureInfo.CurrentCulture) ?? "";
                    sb.Append("<td>");
                    sb.Append(System.Security.SecurityElement.Escape(value));
                    sb.AppendLine("</td>");
                }
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table></body></html>");
            return sb.ToString();
        }

        private void Print()
        {
            if (dataGridView1.Rows.Count == 0)
                throw new InvalidOperationException("No hay datos para imprimir.");

            using var preview = new PrintPreviewDialog
            {
                Document = _printDoc,
                Width = 1100,
                Height = 800
            };

            preview.ShowDialog();
        }

        private void PrintDoc_BeginPrint(object? sender, PrintEventArgs e)
        {
            _printRowIndex = 0;
            _printPageNumber = 1;
        }

        private void PrintDoc_PrintPage(object? sender, PrintPageEventArgs e)
        {
            int left = e.MarginBounds.Left;
            int top = e.MarginBounds.Top;
            int bottom = e.MarginBounds.Bottom;

            using var font = new Font("Segoe UI", 9);
            using var fontHeader = new Font("Segoe UI", 9, FontStyle.Bold);
            using var pen = new Pen(Color.Black);

            int rowHeight = (int)(font.GetHeight(e.Graphics) + 10);
            int y = top;

            e.Graphics.DrawString("Reporte de Pago a Motorista", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Black, left, y);
            y += 28;

            e.Graphics.DrawString(
                $"Desde: {dtpDesde.Value:yyyy-MM-dd}  Hasta: {dtpHasta.Value:yyyy-MM-dd}  Transportista: {cmbTransportista.Text}",
                font,
                Brushes.Black,
                left,
                y
            );
            y += 22;

            e.Graphics.DrawString($"Página: {_printPageNumber}", font, Brushes.Black, e.MarginBounds.Right - 120, top);

            var cols = dataGridView1.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            if (cols.Count == 0)
            {
                e.HasMorePages = false;
                return;
            }

            int tableWidth = e.MarginBounds.Width;
            int colWidth = Math.Max(60, tableWidth / cols.Count);

            int x = left;
            foreach (var col in cols)
            {
                var rect = new Rectangle(x, y, colWidth, rowHeight);
                e.Graphics.DrawRectangle(pen, rect);
                e.Graphics.DrawString(col.HeaderText, fontHeader, Brushes.Black, rect, new StringFormat { LineAlignment = StringAlignment.Center });
                x += colWidth;
            }
            y += rowHeight;

            while (_printRowIndex < dataGridView1.Rows.Count)
            {
                var row = dataGridView1.Rows[_printRowIndex];
                if (row.IsNewRow)
                {
                    _printRowIndex++;
                    continue;
                }

                if (y + rowHeight > bottom)
                {
                    _printPageNumber++;
                    e.HasMorePages = true;
                    return;
                }

                x = left;
                foreach (var col in cols)
                {
                    var rect = new Rectangle(x, y, colWidth, rowHeight);
                    e.Graphics.DrawRectangle(pen, rect);

                    string value = Convert.ToString(row.Cells[col.Name].Value, CultureInfo.CurrentCulture) ?? "";
                    e.Graphics.DrawString(value, font, Brushes.Black, rect, new StringFormat { LineAlignment = StringAlignment.Center });
                    x += colWidth;
                }

                y += rowHeight;
                _printRowIndex++;
            }

            e.HasMorePages = false;
        }

        private void BtnFiltrar_Click(object? sender, EventArgs e)
        {
            TryLoadReport();
        }

        private void BtnImprimir_Click(object? sender, EventArgs e)
        {
            try
            {
                Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnExportarExcel_Click(object? sender, EventArgs e)
        {
            try
            {
                ExportToXlsHtml();
                MessageBox.Show("Exportación completada.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void dtpDesde_ValueChanged(object? sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
                dtpHasta.Value = dtpDesde.Value.Date;
        }

        private void dtpHasta_ValueChanged(object? sender, EventArgs e)
        {
            if (dtpHasta.Value.Date < dtpDesde.Value.Date)
                dtpDesde.Value = dtpHasta.Value.Date;
        }
    }
}
