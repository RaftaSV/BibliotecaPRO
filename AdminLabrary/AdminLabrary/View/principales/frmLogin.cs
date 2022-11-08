using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminLabrary.formularios.principales;
using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;

namespace AdminLabrary.View.principales
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            picVer.Visible = true;
            picOcultar.Visible = false;
        }

        public static frmPrincipal f = new frmPrincipal();
        public void btnIniciarsesion_Click(object sender, EventArgs e)

        {
            registro.Close();
            string u = txtUsuario.Text;

            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                var lista = from admin in db.Roles
                            from lec in db.Lectores
                            where admin.Usuario == txtUsuario.Text
                            && admin.Contraseña == txtContraseña.Text
                            && admin.Id_Lector == lec.Id_Lector
                            && lec.estado ==0
                            && admin.estado == 0
                           

                            select new
                            {
                                ID = admin.Id_rol,
                                Nombre = admin.Usuario,
                                contaseña = admin.Contraseña,
                                idLector = admin.Id_Lector,
                                rol = admin.Rol
                            };


                if (lista.Count() > 0)
                {

                    string usu = txtUsuario.Text;
                    f.lblUsuarioARecibir.Text = usu;
                    foreach (var i in lista)
                    {
                        if(i.rol == 0)
                        {
                           frmLogin.f.inicio();
                            frmPrincipal.Sol.solicitud.idlector = i.idLector;
                            frmPrincipal.Sol.ID = i.idLector;
                            frmPrincipal.Sol.Loging = 0;
                            frmPrincipal.Sol.solicitud.btnSeleccionarLector.Visible = false;
                            frmPrincipal.Sol.solicitud.txtLector.Visible = false;
                            frmPrincipal.Sol.solicitud.lblLector.Visible = false;
                            frmPrincipal.Sol.dgvSolicitudes.Columns["RECIBIR"].Visible = false;

                            frmLogin.f.rol = 0;
                            frmLogin.f.roles();
                            

                        }
                        else
                        {
                            frmLogin.f.inicio();
                            frmPrincipal.prestamos.alquiler.idAdmin = i.ID;
                            frmPrincipal.Sol.solicitud.idlector = i.idLector;
                            frmPrincipal.Sol.ID = i.idLector;
                            frmPrincipal.Sol.Loging = 1;
                            frmPrincipal.Sol.solicitud.btnSeleccionarLector.Visible = true;
                            frmPrincipal.Sol.solicitud.txtLector.Visible = true;
                            frmPrincipal.Sol.solicitud.lblLector.Visible = true;
                            frmPrincipal.Sol.dgvSolicitudes.Columns["RECIBIR"].Visible = true;
                            frmLogin.f.rol = 1;
                            frmLogin.f.roles();
                           
                        }
                        
                    }
                    f.Show();
                    this.Hide();


                }
                else
                {
                    txtUsuario.Text = "";
                    txtContraseña.Text = "";
                    txtUsuario.Focus();
                    MessageBox.Show("Usuario o contraseña incorrecto", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        int mostrar = 1;

        private void picVer_Click(object sender, EventArgs e)
        {
            if (mostrar == 1)
            {
                picVer.Hide();
                picOcultar.Show();
                txtContraseña.UseSystemPasswordChar = true;
                mostrar = 0;
            }
            else
            {
                picVer.Show();
                picOcultar.Hide();
                txtContraseña.UseSystemPasswordChar = false;
                mostrar = 1;
            }
        }
        frmRegistro registro = new frmRegistro();
        private void label1_Click(object sender, EventArgs e)
        {
            registro.limpiar(); 
            registro.Show();
        }

    }
}
