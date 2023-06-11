using AdminLabrary.Model;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
        }

        int _mostrar;
        private void picOcultar_Click(object sender, EventArgs e)
        {
            if (_mostrar == 0)
            {
                picVer.Hide();
                picOcultar.Show();
                txtContraseña.UseSystemPasswordChar = false;
                _mostrar = 1;
            }
            else
            {
                picVer.Show();
                picOcultar.Hide();
                txtContraseña.UseSystemPasswordChar = true;
                _mostrar = 0;
            }
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true;
            picOcultar.Hide();
            btnRegistrar.Enabled = true;
        }

        private void picVer_Click(object sender, EventArgs e)
        {
            if (_mostrar == 0)
            {
                picVer.Hide();
                picOcultar.Show();
                txtContraseña.UseSystemPasswordChar = false;
                _mostrar = 1;
            }
            else
            {
                picVer.Show();
                picOcultar.Hide();
                txtContraseña.UseSystemPasswordChar = true;
                _mostrar = 0;
            }
        }

        private string HashSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string name = txtNombre.Text.Trim();
            string lastName = txtApellidos.Text.Trim();
            string user = txtUsuario.Text.Trim();
            string pass = txtContraseña.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("El nombre de usuario es obligatorio");
                txtNombre.Focus();
            }
            else if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("El apellido de usuario es obligatorio");
                txtApellidos.Focus();
            }
            else if (string.IsNullOrWhiteSpace(user))
            {
                MessageBox.Show("El campo de usuario es obligatorio");
                txtUsuario.Focus();
            }
            else if (string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("El campo de contraseña es obligatorio");
                txtContraseña.Focus();
            }
            else
            {
                string hashedPassword = HashSHA256(pass);

                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    Lectores lec = new Lectores
                    {
                        Nombres = name,
                        Apellidos = lastName,
                        estado = 0
                    };
                    db.Lectores.Add(lec);
                    db.SaveChanges();
                    int idUser = lec.Id_Lector;
                    Roles rol = new Roles
                    {
                        Usuario = user,
                        Contraseña = hashedPassword,
                        Id_Lector = idUser,
                        Rol = 0,
                        estado = 0
                    };
                    db.Roles.Add(rol);
                    db.SaveChanges();
                    Close();
                }
            }
        }
    }
}
