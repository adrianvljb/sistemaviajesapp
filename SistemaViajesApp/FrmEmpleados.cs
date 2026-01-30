using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaViajesApp
{
    public partial class FrmEmpleados : Form
    {
        private readonly EmpleadosService _service = new EmpleadosService();
        private int _empleadoSeleccionadoId = -1;

        public FrmEmpleados()
        {
            InitializeComponent();

            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            var rol = Sesion.Rol ?? "";

            if (!PermisosEmpleados.PuedeVer(rol))
            {
                MessageBox.Show("Acceso denegado.");
                BeginInvoke(new Action(() => Close()));
                return;
            }

            BtnNuevo.Enabled = PermisosEmpleados.PuedeCrear(rol);
            BtnGuardar.Enabled = PermisosEmpleados.PuedeCrear(rol) || PermisosEmpleados.PuedeEditar(rol);
            BtnEditar.Enabled = PermisosEmpleados.PuedeEditar(rol);
            BtnEliminar.Enabled = PermisosEmpleados.PuedeEliminar(rol);

            txtNombre.Enabled = BtnGuardar.Enabled;
            cmbSucursal.Enabled = BtnGuardar.Enabled;
            txtDistancia.Enabled = BtnGuardar.Enabled;

            dataGridView1.AutoGenerateColumns = true;

            CargarSucursales();
            CargarEmpleados();
            LimpiarCampos();
        }

        private void CargarSucursales()
        {
            var conexion = new ConexionDB();
            using var conn = conexion.GetConnection();
            conn.Open();

            using var da = new Microsoft.Data.SqlClient.SqlDataAdapter(
                "SELECT IdSucursal, Nombre FROM Sucursales WHERE Activo = 1 ORDER BY Nombre", conn);

            var dt = new DataTable();
            da.Fill(dt);

            cmbSucursal.DataSource = dt;
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "IdSucursal";
            cmbSucursal.SelectedIndex = -1;
        }

        private void CargarEmpleados()
        {
            dataGridView1.DataSource = _service.ListarActivos();
        }

        private void LimpiarCampos()
        {
            _empleadoSeleccionadoId = -1;
            txtNombre.Clear();
            txtDistancia.Clear();
            cmbSucursal.SelectedIndex = -1;
        }

        private void BtnNuevo_Click_1(object sender, EventArgs e)
        {
            if (!PermisosEmpleados.PuedeCrear(Sesion.Rol ?? "")) return;
            LimpiarCampos();
            txtNombre.Focus();
        }

        private void BtnGuardar_Click_1(object sender, EventArgs e)
        {
            var rol = Sesion.Rol ?? "";

            if (_empleadoSeleccionadoId == -1 && !PermisosEmpleados.PuedeCrear(rol)) return;
            if (_empleadoSeleccionadoId != -1 && !PermisosEmpleados.PuedeEditar(rol)) return;

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                cmbSucursal.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtDistancia.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            if (!decimal.TryParse(txtDistancia.Text, out var distancia))
            {
                MessageBox.Show("Distancia inválida.");
                return;
            }

            var nombre = txtNombre.Text.Trim();
            var idSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);
            var usuarioRegistro = 1;

            try
            {
                if (_empleadoSeleccionadoId == -1)
                {
                    _service.Insertar(nombre, idSucursal, distancia, usuarioRegistro);
                }
                else
                {
                    _service.Actualizar(_empleadoSeleccionadoId, nombre, idSucursal, distancia);
                }

                CargarEmpleados();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEditar_Click_1(object sender, EventArgs e)
        {
            if (!PermisosEmpleados.PuedeEditar(Sesion.Rol ?? "")) return;
            if (dataGridView1.CurrentRow == null) return;

            _empleadoSeleccionadoId =
                Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdEmpleado"].Value);

            txtNombre.Text =
                dataGridView1.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "";

            txtDistancia.Text =
                dataGridView1.CurrentRow.Cells["DistanciaKm"].Value?.ToString() ?? "";

            var sucursalNombre =
                dataGridView1.CurrentRow.Cells["Sucursal"].Value?.ToString() ?? "";

            for (int i = 0; i < cmbSucursal.Items.Count; i++)
            {
                if (cmbSucursal.Items[i] is DataRowView rv &&
                    (rv["Nombre"]?.ToString() ?? "") == sucursalNombre)
                {
                    cmbSucursal.SelectedIndex = i;
                    break;
                }
            }
        }

        private void BtnEliminar_Click_1(object sender, EventArgs e)
        {
            if (!PermisosEmpleados.PuedeEliminar(Sesion.Rol ?? "")) return;
            if (dataGridView1.CurrentRow == null) return;

            var idEmp =
                Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdEmpleado"].Value);

            if (MessageBox.Show("¿Desea desactivar este empleado?",
                "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            _service.Desactivar(idEmp);
            CargarEmpleados();
            LimpiarCampos();
        }

        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtDistancia_TextChanged(object sender, EventArgs e) { }
    }
}
