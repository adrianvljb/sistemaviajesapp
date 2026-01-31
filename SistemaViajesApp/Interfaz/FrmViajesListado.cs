using System;
using System.Windows.Forms;
using SistemaViajesApp.Services;

namespace SistemaViajesApp
{
    public partial class FrmViajesListado : Form
    {
        private readonly ViajesService _service = new ViajesService();

        public FrmViajesListado()
        {
            InitializeComponent();

            ConfigurarGrids();
            CargarFiltros();
            CargarViajes();
        }

        // =========================
        //  UI
        // =========================
        private void ConfigurarGrids()
        {
            // dataGridView1 = viajes
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // dataGridView2 = detalle
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.ReadOnly = true;
            dataGridView2.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // cargar detalle al seleccionar viaje
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void CargarFiltros()
        {
            try
            {
                // combos
                cmbSucursal.DisplayMember = "Nombre";
                cmbSucursal.ValueMember = "IdSucursal";
                cmbSucursal.DataSource = _service.GetSucursales();
                cmbSucursal.SelectedIndex = -1; // sin filtro

                cmbTransportista.DisplayMember = "Nombre";
                cmbTransportista.ValueMember = "IdTransportista";
                cmbTransportista.DataSource = _service.GetTransportistas();
                cmbTransportista.SelectedIndex = -1; // sin filtro

                // fechas por defecto (últimos 7 días)
                dtpDesde.Value = DateTime.Today.AddDays(-7);
                dtpHasta.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando filtros: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        //  DATA
        // =========================
        private void CargarViajes()
        {
            try
            {
                var desde = dtpDesde.Value.Date;
                var hasta = dtpHasta.Value.Date;

                // seguridad: si invierten fechas
                if (desde > hasta)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? idSucursal = GetSelectedInt(cmbSucursal);
                int? idTransportista = GetSelectedInt(cmbTransportista);

                var viajes = _service.ListarViajes(desde, hasta, idSucursal, idTransportista);

                dataGridView1.DataSource = viajes;

                // limpiar detalle al recargar
                dataGridView2.DataSource = null;

                // autoseleccionar el primero (si existe)
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[0].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                    CargarDetalleSeleccionado();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando viajes: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDetalleSeleccionado()
        {
            try
            {
                int? idViaje = GetIdViajeSeleccionado();
                if (idViaje == null)
                {
                    dataGridView2.DataSource = null;
                    return;
                }

                var detalle = _service.ObtenerDetalle(idViaje.Value);
                dataGridView2.DataSource = detalle;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando detalle: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        //  HELPERS
        // =========================
        private static int? GetSelectedInt(ComboBox combo)
        {
            if (combo.SelectedIndex < 0 || combo.SelectedValue == null)
                return null;

            return Convert.ToInt32(combo.SelectedValue);
        }

        private int? GetIdViajeSeleccionado()
        {
            if (dataGridView1.CurrentRow == null)
                return null;

            // Caso ideal: columna se llama IdViaje (porque el DTO trae IdViaje)
            var cell = dataGridView1.CurrentRow.Cells["IdViaje"];
            if (cell?.Value != null)
                return Convert.ToInt32(cell.Value);

            // Fallback: si por algún motivo no se llama así, intenta primera columna
            if (dataGridView1.CurrentRow.Cells.Count > 0 && dataGridView1.CurrentRow.Cells[0].Value != null)
                return Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            return null;
        }

        // =========================
        //  EVENTOS (EXACTOS A TU DESIGNER)
        // =========================
        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            CargarViajes();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No hago reload automático para no saturar.
            // Si quieres que filtre al cambiar combo, descomenta:
            // CargarViajes();
        }

        private void cmbTransportista_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Igual que arriba (sin inventar flujo).
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            // opcional: validación suave
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
                dtpHasta.Value = dtpDesde.Value.Date;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            // opcional: validación suave
            if (dtpHasta.Value.Date < dtpDesde.Value.Date)
                dtpDesde.Value = dtpHasta.Value.Date;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            CargarDetalleSeleccionado();
        }
    }
}
