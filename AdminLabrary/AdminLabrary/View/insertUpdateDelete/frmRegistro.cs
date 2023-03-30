using System;
using System.Windows.Forms;
using AdminLabrary.Model;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
        }

        int mostrar;
        private void picOcultar_Click(object sender, EventArgs e)
        {

            if (mostrar == 0)
            {
                picVer.Hide();
                picOcultar.Show();
                txtContraseña.UseSystemPasswordChar = false;
                mostrar = 1;
            }
            else
            {
                picVer.Show();
                picOcultar.Hide();
                txtContraseña.UseSystemPasswordChar = true;
                mostrar = 0;
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
            if (mostrar == 0)
            {
                picVer.Hide();
                picOcultar.Show();
                txtContraseña.UseSystemPasswordChar = false;
                mostrar = 1;
            }
            else
            {
                picVer.Show();
                picOcultar.Hide();
                txtContraseña.UseSystemPasswordChar = true;
                mostrar = 0;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            String name = txtNombre.Text;
            String lastName = txtApellidos.Text;
            String User = txtUsuario.Text;
            string pass = txtContraseña.Text;

            if(name == "")
            {
                MessageBox.Show("El nombre de usuario es obligatorio");
                txtNombre.Focus();
            }else if (lastName == "")
            {
                MessageBox.Show("El apellido de usuario es obligatorio");
                txtApellidos.Focus();
            }
            else if (User == "")
            {
                MessageBox.Show("El campo  usuario es obligatorio");
                txtUsuario.Focus();
            }
            else if (pass == "")
            {
                MessageBox.Show("La el campo contraseña es obligatorio");
                txtContraseña.Focus();
            }
            else
            {
                Console.WriteLine(name + User + pass + lastName);
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
                        Usuario = User,
                        Contraseña = pass,
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
