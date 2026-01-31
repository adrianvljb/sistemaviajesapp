using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SistemaViajesApp.Services;

namespace SistemaViajesApp
{
    public partial class FrmViajesIngreso : Form
    {
        private readonly ViajesService _service = new ViajesService();

        private BindingList<DetalleEmpleadoUI> _detalle = new BindingList<DetalleEmpleadoUI>();

        private int _idUsuarioRegistro;

        public FrmViajesIngreso()
        {
            InitializeComponent();

            ConfigurarGrid();
            CargarCombos();
            InicializarUsuarioRegistro();
            ResetFormulario();
        }

        private void ConfigurarGrid()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = _detalle;
        }

        private void CargarCombos()
        {
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "IdSucursal";
            cmbSucursal.DataSource = _service.GetSucursales();
            cmbSucursal.SelectedIndex = -1;

            cmbTransportista.DisplayMember = "Nombre";
            cmbTransportista.ValueMember = "IdTransportista";
            cmbTransportista.DataSource = _service.GetTransportistas();
            cmbTransportista.SelectedIndex = -1;

            cmbEmpleado.DisplayMember = "Nombre";
            cmbEmpleado.ValueMember = "IdEmpleado";
            cmbEmpleado.DataSource = _service.GetEmpleados();
            cmbEmpleado.SelectedIndex = -1;
        }

        private void InicializarUsuarioRegistro()
        {
            // Replace "admin" with the logged-in username if available in the form/session.
            const string usuario = "admin";
            _idUsuarioRegistro = _service.ObtenerIdUsuarioPorUsuario(usuario);
        }

        private void ResetFormulario()
        {
            dtpFechaViaje.Value = DateTime.Today;

            txtDistanciaKm.Text = "";
            cmbEmpleado.SelectedIndex = -1;

            _detalle = new BindingList<DetalleEmpleadoUI>();
            dataGridView1.DataSource = _detalle;
        }

        private bool TryParseKm(out decimal km)
        {
            km = 0m;
            var raw = (txtDistanciaKm.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(raw))
                return false;

            raw = raw.Replace(',', '.');
            return decimal.TryParse(raw, NumberStyles.Number, CultureInfo.InvariantCulture, out km) && km > 0;
        }

        private decimal GetTarifaPorKmSeleccionada()
        {
            if (cmbTransportista.SelectedValue == null)
                throw new InvalidOperationException("Transportista no seleccionado.");

            int idTransportista = Convert.ToInt32(cmbTransportista.SelectedValue);
            return _service.ObtenerTarifaPorKmTransportista(idTransportista);
        }

        private void AgregarEmpleadoDetalle()
        {
            if (cmbEmpleado.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un empleado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TryParseKm(out var km))
            {
                MessageBox.Show("Ingrese una distancia válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEmpleado = Convert.ToInt32(cmbEmpleado.SelectedValue);

            if (_detalle.Any(x => x.IdEmpleado == idEmpleado))
            {
                MessageBox.Show("El empleado ya está agregado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tarifaKm = GetTarifaPorKmSeleccionada();
            var tarifaCalculada = Math.Round(km * tarifaKm, 2);

            _detalle.Add(new DetalleEmpleadoUI
            {
                IdEmpleado = idEmpleado,
                Empleado = cmbEmpleado.Text,
                DistanciaKm = km,
                TarifaCalculada = tarifaCalculada
            });

            txtDistanciaKm.Text = "";
            cmbEmpleado.SelectedIndex = -1;
        }

        private void QuitarEmpleadoDetalle()
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is not DetalleEmpleadoUI item)
                return;

            _detalle.Remove(item);
        }

        private bool ValidarGuardar()
        {
            if (cmbSucursal.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una sucursal.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbTransportista.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un transportista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_detalle.Count == 0)
            {
                MessageBox.Show("Agregue al menos un empleado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void GuardarViaje()
        {
            if (!ValidarGuardar())
                return;

            try
            {
                var req = new ViajeGuardarRequest
                {
                    FechaViaje = dtpFechaViaje.Value.Date,
                    IdSucursal = Convert.ToInt32(cmbSucursal.SelectedValue),
                    IdTransportista = Convert.ToInt32(cmbTransportista.SelectedValue),
                    UsuarioRegistro = _idUsuarioRegistro,
                    Detalle = _detalle.Select(x => new ViajeEmpleadoDetalle
                    {
                        IdEmpleado = x.IdEmpleado,
                        DistanciaKm = x.DistanciaKm,
                        TarifaCalculada = x.TarifaCalculada
                    }).ToList()
                };

                int idViaje = _service.InsertarViaje(req);

                MessageBox.Show($"Viaje guardado. ID: {idViaje}", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e) { }

        private void cmbTransportista_SelectedIndexChanged(object sender, EventArgs e) { }

        private void dtpFecha_ValueChanged(object sender, EventArgs e) { }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e) { }

        private void txtDistanciaKm_TextChanged(object sender, EventArgs e) { }

        private void BtnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            AgregarEmpleadoDetalle();
        }

        private void BtnQuitarEmpleado_Click(object sender, EventArgs e)
        {
            QuitarEmpleadoDetalle();
        }

        private void BtnGuardar_Click_1(object sender, EventArgs e)
        {
            GuardarViaje();
        }

        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private class DetalleEmpleadoUI
        {
            public int IdEmpleado { get; set; }
            public string Empleado { get; set; } = "";
            public decimal DistanciaKm { get; set; }
            public decimal TarifaCalculada { get; set; }
        }
    }
}
