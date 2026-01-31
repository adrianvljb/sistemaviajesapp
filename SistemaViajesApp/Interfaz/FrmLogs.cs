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
    public partial class FrmLogs : Form
    {
        private readonly LogService _logService = new LogService();
        private DataTable _data = new DataTable();

        private readonly PrintDocument _printDoc = new PrintDocument();
        private int _printRowIndex;
        private int _printPageNumber;

        public FrmLogs()
        {
            InitializeComponent();

            ConfigureGrid();
            InitFilters();
            LoadUsuarios();

            WireEvents();

            Shown += FrmLogs_Shown;

            _printDoc.BeginPrint += PrintDoc_BeginPrint;
            _printDoc.PrintPage += PrintDoc_PrintPage;
        }

        private void FrmLogs_Shown(object? sender, EventArgs e)
        {
            TryLoad();
        }

        private void WireEvents()
        {
            BtnFiltrar.Click += BtnFiltrar_Click;
            BtnImprimir.Click += BtnImprimir_Click;
            BtnExportarExcel.Click += BtnExportarExcel_Click;
            BtnCerrar.Click += BtnCerrar_Click;
        }

        private void ConfigureGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void InitFilters()
        {
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;

            cmbModulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModulo.Items.Clear();
            cmbModulo.Items.Add("Todos");
            cmbModulo.Items.Add("Login");
            cmbModulo.Items.Add("Empleados");
            cmbModulo.Items.Add("Transportistas");
            cmbModulo.Items.Add("Viajes");
            cmbModulo.Items.Add("Reportes");
            cmbModulo.Items.Add("Sistema");
            cmbModulo.SelectedIndex = 0;

            cmbExitoso.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbExitoso.Items.Clear();
            cmbExitoso.Items.Add("Todos");
            cmbExitoso.Items.Add("Exitoso");
            cmbExitoso.Items.Add("Fallido");
            cmbExitoso.SelectedIndex = 0;

            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadUsuarios()
        {
            var dt = _logService.ListarUsuariosEnLogs();

            if (!dt.Columns.Contains("Usuario"))
                throw new InvalidOperationException("La consulta de usuarios no devolvió la columna 'Usuario'.");

            var row = dt.NewRow();
            row["Usuario"] = "Todos";
            dt.Rows.InsertAt(row, 0);

            cmbUsuario.DisplayMember = "Usuario";
            cmbUsuario.ValueMember = "Usuario";
            cmbUsuario.DataSource = dt;
            cmbUsuario.SelectedIndex = 0;
        }

        private void TryLoad()
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Logs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadData()
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            if (desde > hasta)
                throw new InvalidOperationException("El rango de fechas no es válido.");

            string? modulo = cmbModulo.SelectedItem?.ToString();
            if (string.Equals(modulo, "Todos", StringComparison.OrdinalIgnoreCase))
                modulo = null;

            string? usuarioFiltro = GetUsuarioSeleccionado();

            bool? exitoso = cmbExitoso.SelectedIndex switch
            {
                1 => true,
                2 => false,
                _ => null
            };

            _data = _logService.Listar(desde, hasta, modulo, usuarioFiltro, exitoso);

            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _data;

            FormatColumns();
        }

        private string? GetUsuarioSeleccionado()
        {
            if (cmbUsuario.SelectedIndex < 0)
                return null;

            if (cmbUsuario.SelectedItem is DataRowView drv)
            {
                string value = Convert.ToString(drv["Usuario"])?.Trim() ?? "";
                if (value.Equals("Todos", StringComparison.OrdinalIgnoreCase))
                    return null;
                return value.Length == 0 ? null : value;
            }

            if (cmbUsuario.SelectedValue != null)
            {
                string value = cmbUsuario.SelectedValue.ToString()!.Trim();
                if (value.Equals("Todos", StringComparison.OrdinalIgnoreCase))
                    return null;
                return value.Length == 0 ? null : value;
            }

            return null;
        }

        private void FormatColumns()
        {
            if (dataGridView1.Columns["FechaHora"] != null)
                dataGridView1.Columns["FechaHora"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

            if (dataGridView1.Columns["Exitoso"] != null)
                dataGridView1.Columns["Exitoso"].HeaderText = "OK";
        }

        private void BtnFiltrar_Click(object? sender, EventArgs e)
        {
            TryLoad();
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

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void ExportToXlsHtml()
        {
            if (_data.Rows.Count == 0)
                throw new InvalidOperationException("No hay datos para exportar.");

            using var sfd = new SaveFileDialog
            {
                Filter = "Excel (*.xls)|*.xls",
                FileName = $"Logs_{DateTime.Now:yyyyMMdd_HHmm}.xls"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            string html = BuildHtmlTable(_data, "Logs del sistema");
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

            int rowHeight = (int)(font.GetHeight() + 10);
            int y = top;

            e.Graphics.DrawString("Logs del sistema", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Black, left, y);
            y += 28;

            e.Graphics.DrawString($"Desde: {dtpDesde.Value:yyyy-MM-dd}  Hasta: {dtpHasta.Value:yyyy-MM-dd}", font, Brushes.Black, left, y);
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
            int colWidth = Math.Max(70, tableWidth / cols.Count);

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
    }
}
