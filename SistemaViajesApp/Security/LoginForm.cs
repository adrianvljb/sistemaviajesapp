using SistemaViajesApp;
using SistemaViajesApp.Security;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaViajesApp
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService = new AuthService();

        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load;
        }

        private void LoginForm_Load(object? sender, EventArgs e)
        {
            txtContrasena.PasswordChar = '*';

            if (lblMensaje != null)
                lblMensaje.Text = "";
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            if (lblMensaje != null)
                lblMensaje.Text = "";

            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MostrarMsg("Ingrese usuario y contraseña.", Color.DarkOrange);
                return;
            }

            try
            {
                string? rol = _authService.ValidarUsuario(usuario, contrasena);

                if (!string.IsNullOrWhiteSpace(rol))
                {
                    Sesion.Usuario = usuario;
                    Sesion.Rol = rol;

                    // ✅ Prueba de conexión / login: mostrar usuario y rol (como lo querías)
                    MostrarMsg($"OK ✅ Usuario: {Sesion.Usuario} | Rol: {Sesion.Rol}", Color.Green);

                    // ✅ Permite que Program.cs abra el MainForm
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MostrarMsg("Usuario o contraseña incorrectos.", Color.Red);
                }
            }
            catch (Exception ex)
            {
                MostrarMsg("Error: " + ex.Message, Color.Red);
            }
        }

        private void btnSalir_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        // ✅ Puentes por si el Designer quedó apuntando a *_Click_1
        private void btnLogin_Click_1(object? sender, EventArgs e) => btnLogin_Click(sender, e);
        private void btnSalir_Click_1(object? sender, EventArgs e) => btnSalir_Click(sender, e);

        private void MostrarMsg(string texto, Color color)
        {
            if (lblMensaje == null)
            {
                MessageBox.Show(texto);
                return;
            }

            lblMensaje.ForeColor = color;
            lblMensaje.Text = texto;
        }
    }
}