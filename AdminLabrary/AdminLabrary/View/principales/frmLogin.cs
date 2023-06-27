using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;

namespace AdminLabrary.View.principales
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            picVer.Visible = true;
            picOcultar.Visible = false;
        }

        public static FrmPrincipal F = new FrmPrincipal();

        public void btnIniciarsesion_Click(object sender, EventArgs e)
        {
            if (_registro != null)
            {
                _registro.Close();
            }

            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                string usuario = txtUsuario.Text;
                string contraseña = txtContraseña.Text;

                byte[] contraseñaBytes = Encoding.UTF8.GetBytes(contraseña);
                byte[] contraseñaHash = SHA256.Create().ComputeHash(contraseñaBytes);
                string contraseñaHashString = BitConverter.ToString(contraseñaHash).Replace("-", string.Empty);

                var lista = from admin in db.Roles
                            from lec in db.Lectores
                            where admin.Usuario == usuario
                            && admin.Contraseña == contraseñaHashString
                            && admin.Id_Lector == lec.Id_Lector
                            && lec.estado == 0
                            && admin.estado == 0
                            select new
                            {
                                ID = admin.Id_rol,
                                Nombre = admin.Usuario,
                                contaseña = admin.Contraseña,
                                idLector = admin.Id_Lector,
                                rol = admin.Rol
                            };

                if (lista.Any())
                {
                    string usu = usuario;
                    F.lblUsuarioARecibir.Text = usu;
                    foreach (var i in lista)
                    {
                        if (i.rol == 0)
                        {
                            F.Inicio();
                            FrmPrincipal.Sol.Solicitud.Idlector = i.idLector;
                            FrmPrincipal.Sol.Id = i.idLector;
                            FrmPrincipal.Sol.Loging = 0;
                            FrmPrincipal.Sol.Solicitud.btnSeleccionarLector.Visible = false;
                            FrmPrincipal.Sol.Solicitud.txtLector.Visible = false;
                            FrmPrincipal.Sol.Solicitud.lblLector.Visible = false;
                            FrmPrincipal.Sol.dgvSolicitudes.Columns["RECIBIR"].Visible = false;
                            F.Rol = 0;
                            F.Roles();
                        }
                        else if (i.rol == 1)
                        {
                            // Código específico para el rol de administrador (rol = 1)
                            // ...
                            // Por ejemplo:
                            F.Inicio();
                            FrmPrincipal.Prestamos.Alquiler.IdAdmin = i.ID;
                            FrmPrincipal.Sol.Solicitud.Idlector = i.idLector;
                            FrmPrincipal.Sol.Id = i.idLector;
                            FrmPrincipal.Sol.Loging = 1;
                            FrmPrincipal.Sol.Solicitud.btnSeleccionarLector.Visible = true;
                            FrmPrincipal.Sol.Solicitud.txtLector.Visible = true;
                            FrmPrincipal.Sol.Solicitud.lblLector.Visible = true;
                            FrmPrincipal.Sol.dgvSolicitudes.Columns["RECIBIR"].Visible = true;
                            F.Rol = 1;
                            F.Roles();
                        }
                        else
                        {
                            // Otros casos de roles, si los hay
                            // ...
                        }
                    }
                    F.Show();
                    Hide();
                }
                else
                {
                    txtUsuario.Text = "";
                    txtContraseña.Text = "";
                    txtUsuario.Focus();
                    MessageBox.Show("Usuario o contraseña incorrecto", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = '*';

        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        int _mostrar = 1;

        private void picVer_Click(object sender, EventArgs e)
        {
            if (_mostrar == 1)
            {
                picVer.Hide();
                picOcultar.Show();
                txtContraseña.UseSystemPasswordChar = true;
                _mostrar = 0;
            }
            else
            {
                picVer.Show();
                picOcultar.Hide();
                txtContraseña.UseSystemPasswordChar = false;
                _mostrar = 1;
            }
        }

        FrmRegistro _registro;

        private void label1_Click(object sender, EventArgs e)
        {
            _registro = new FrmRegistro();
            _registro.Limpiar();
            _registro.Show();
        }
    }
}
