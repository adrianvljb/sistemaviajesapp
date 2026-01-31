using System;
using System.Windows.Forms;

namespace SistemaViajesApp
{
    public partial class FrmTransportistas : Form
    {
        private readonly TransportistasService _service = new TransportistasService();
        private int _transportistaSeleccionadoId = -1;

        public FrmTransportistas()
        {
            InitializeComponent();

            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = true;
        }

        private void FrmTransportistas_Load(object sender, EventArgs e)
        {
            var rol = Sesion.Rol ?? "";

            if (!PermisosTransportistas.PuedeVer(rol))
            {
                MessageBox.Show("Acceso denegado.");
                BeginInvoke(new Action(() => Close()));
                return;
            }

            BtnNuevo.Enabled = PermisosTransportistas.PuedeCrear(rol);
            BtnGuardar.Enabled = PermisosTransportistas.PuedeCrear(rol) || PermisosTransportistas.PuedeEditar(rol);
            BtnEditar.Enabled = PermisosTransportistas.PuedeEditar(rol);
            BtnEliminar.Enabled = PermisosTransportistas.PuedeEliminar(rol);

            txtNombre.Enabled = BtnGuardar.Enabled;

            CargarTransportistas();
            LimpiarCampos();
        }

        private void CargarTransportistas()
        {
            dataGridView1.DataSource = _service.ListarActivos();
        }

        private void LimpiarCampos()
        {
            _transportistaSeleccionadoId = -1;
            txtNombre.Clear();
            txtNombre.Focus();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (!PermisosTransportistas.PuedeCrear(Sesion.Rol ?? "")) return;
            LimpiarCampos();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            var rol = Sesion.Rol ?? "";

            if (_transportistaSeleccionadoId == -1 && !PermisosTransportistas.PuedeCrear(rol)) return;
            if (_transportistaSeleccionadoId != -1 && !PermisosTransportistas.PuedeEditar(rol)) return;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Complete el nombre.");
                return;
            }

            var nombre = txtNombre.Text.Trim();

            if (_transportistaSeleccionadoId == -1)
                _service.Insertar(nombre);
            else
                _service.Actualizar(_transportistaSeleccionadoId, nombre);

            CargarTransportistas();
            LimpiarCampos();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (!PermisosTransportistas.PuedeEditar(Sesion.Rol ?? "")) return;
            if (dataGridView1.CurrentRow == null) return;

            _transportistaSeleccionadoId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdTransportista"].Value);
            txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "";
            txtNombre.Focus();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!PermisosTransportistas.PuedeEliminar(Sesion.Rol ?? "")) return;
            if (dataGridView1.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdTransportista"].Value);

            if (MessageBox.Show("¿Desea desactivar este transportista?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            _service.Desactivar(id);
            CargarTransportistas();
            LimpiarCampos();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}