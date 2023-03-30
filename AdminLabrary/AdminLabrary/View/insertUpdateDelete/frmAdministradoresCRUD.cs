using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.formularios.principales;
using AdminLabrary.Model;
using AdminLabrary.View.buscar;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class frmAdministradoresCRUD : Form
    {
        public frmAdministradoresCRUD()
        {
            InitializeComponent();
        }

        public int IDLector;
        public int IDAdmin;
        Roles rol = new Roles();

        private void frmAdministradoresCRUD_Load(object sender, EventArgs e)
        {
            
            txtContraseña.UseSystemPasswordChar = true;
            picOcultar.Hide();
        }

        public void Limpiar()
        {
            txtContraseña.Text = "";
            txtLector.Text = "";
            txtUsuario.Text = "";
            txtUsuario.Enabled = true;
            txtContraseña.Enabled = true;
            btnSeleccionar.Enabled = true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text != ""&& txtLector.Text != "" && txtUsuario.Text != "")
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    if (rbtnLector.Checked == true)
                    {
                        rol.Usuario = txtUsuario.Text;
                        rol.Contraseña = txtContraseña.Text;
                        rol.Id_Lector = IDLector;
                        rol.Rol = 0;
                        rol.estado = 0;
                        db.Roles.Add(rol);
                        db.SaveChanges();
                        Limpiar();
                        frmPrincipal.r.CargarDatos();
                        frmPrincipal.admin.CargarDatos();
                        Close();
                    }
                    else
                    {
                        rol.Usuario = txtUsuario.Text;
                        rol.Contraseña = txtContraseña.Text;
                        rol.Id_Lector = IDLector;
                        rol.Rol = 1;
                        rol.estado = 0;
                        db.Roles.Add(rol);
                        db.SaveChanges();
                        Limpiar();
                        frmPrincipal.r.CargarDatos();
                        frmPrincipal.admin.CargarDatos();
                        Close();
                    }


                }

            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios");
            }

        
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                if (rbtnLector.Checked == true)
                {
                    rol = db.Roles.First(buscarID => buscarID.Id_rol == IDAdmin);
                    rol.Usuario = txtUsuario.Text;
                    rol.Contraseña = txtContraseña.Text;
                    rol.Id_Lector = IDLector;
                    rol.Rol = 0;
                    rol.estado = 0;
                    db.Entry(rol).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    frmPrincipal.r.CargarDatos();
                    frmPrincipal.admin.CargarDatos();
                    Close();
                }
                else
                {
                    rol = db.Roles.First(buscarID => buscarID.Id_rol == IDAdmin);
                    rol.Usuario = txtUsuario.Text;
                    rol.Contraseña = txtContraseña.Text;
                    rol.Id_Lector = IDLector;
                    rol.Rol = 1;
                    rol.estado = 0;
                    db.Entry(rol).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    frmPrincipal.r.CargarDatos();
                    frmPrincipal.admin.CargarDatos();
                    Close();
                }
               
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                if (rbtnLector.Checked == true)
                {
                    rol = db.Roles.First(buscarID => buscarID.Id_rol == IDAdmin);
                    rol.Usuario = txtUsuario.Text;
                    rol.Contraseña = txtContraseña.Text;
                    rol.Id_Lector = IDLector;
                    rol.Rol = 0;
                    rol.estado = 1;
                    db.Entry(rol).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    frmPrincipal.r.CargarDatos();
                    frmPrincipal.admin.CargarDatos();
                    Close();
                }
                else
                {
                    rol = db.Roles.First(buscarID => buscarID.Id_rol == IDAdmin);
                    rol.Usuario = txtUsuario.Text;
                    rol.Contraseña = txtContraseña.Text;
                    rol.Id_Lector = IDLector;
                    rol.Rol = 1;
                    rol.estado = 1;
                    db.Entry(rol).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    frmPrincipal.r.CargarDatos();
                    frmPrincipal.admin.CargarDatos();
                    Close();
                }

            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            frmBuscarLector lec = new frmBuscarLector();
            lec.indicador = 1;
            lec.ShowDialog();
        }

        int mostrar;
        private void btnVerC_Click(object sender, EventArgs e)
        {
           
            if (mostrar==0)
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
                mostrar=0;
            }
            
        }
    }
}
