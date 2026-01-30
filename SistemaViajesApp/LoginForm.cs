using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SistemaViajesApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load;
        }

        private void LoginForm_Load(object? sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Ingrese usuario y contraseña", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var db = new ConexionDB();
                using SqlConnection conn = db.GetConnection();
                conn.Open();

                string sql = @"
                    SELECT Rol
                    FROM Usuarios
                    WHERE Usuario = @Usuario
                      AND Contrasena = @Contrasena
                      AND Activo = 1;";

                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text.Trim());
                cmd.Parameters.AddWithValue("@Contrasena", txtContrasena.Text.Trim());

                var resultado = cmd.ExecuteScalar();

                if (resultado is not null)
                {
                    Sesion.Usuario = txtUsuario.Text.Trim();
                    Sesion.Rol = resultado.ToString()!;

                    MessageBox.Show(
                        $"Conexión OK ✅\n\nUsuario: {Sesion.Usuario}\nRol: {Sesion.Rol}",
                        "Login exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );


                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Acceso denegado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    $"SqlException #{ex.Number}\n{ex.Message}",
                    "Error SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}