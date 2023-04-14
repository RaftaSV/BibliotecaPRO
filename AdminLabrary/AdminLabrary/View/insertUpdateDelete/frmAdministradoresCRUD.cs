﻿using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.Model;
using AdminLabrary.View.buscar;
using AdminLabrary.View.principales;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class FrmAdministradoresCrud : Form
    {
        public FrmAdministradoresCrud()
        {
            InitializeComponent();
        }

        public int IdLector;
        public int IdAdmin;
        Roles _rol = new Roles();

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
                    if (rbtnLector.Checked)
                    {
                        _rol.Usuario = txtUsuario.Text;
                        _rol.Contraseña = txtContraseña.Text;
                        _rol.Id_Lector = IdLector;
                        _rol.Rol = 0;
                        _rol.estado = 0;
                        db.Roles.Add(_rol);
                        db.SaveChanges();
                        Limpiar();
                        FrmPrincipal.R.CargarDatos();
                        FrmPrincipal.Admin.CargarDatos();
                        Close();
                    }
                    else
                    {
                        _rol.Usuario = txtUsuario.Text;
                        _rol.Contraseña = txtContraseña.Text;
                        _rol.Id_Lector = IdLector;
                        _rol.Rol = 1;
                        _rol.estado = 0;
                        db.Roles.Add(_rol);
                        db.SaveChanges();
                        Limpiar();
                        FrmPrincipal.R.CargarDatos();
                        FrmPrincipal.Admin.CargarDatos();
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
                if (rbtnLector.Checked)
                {
                    _rol = db.Roles.First(buscarId => buscarId.Id_rol == IdAdmin);
                    _rol.Usuario = txtUsuario.Text;
                    _rol.Contraseña = txtContraseña.Text;
                    _rol.Id_Lector = IdLector;
                    _rol.Rol = 0;
                    _rol.estado = 0;
                    db.Entry(_rol).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.R.CargarDatos();
                    FrmPrincipal.Admin.CargarDatos();
                    Close();
                }
                else
                {
                    _rol = db.Roles.First(buscarId => buscarId.Id_rol == IdAdmin);
                    _rol.Usuario = txtUsuario.Text;
                    _rol.Contraseña = txtContraseña.Text;
                    _rol.Id_Lector = IdLector;
                    _rol.Rol = 1;
                    _rol.estado = 0;
                    db.Entry(_rol).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.R.CargarDatos();
                    FrmPrincipal.Admin.CargarDatos();
                    Close();
                }
               
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                if (rbtnLector.Checked)
                {
                    _rol = db.Roles.First(buscarId => buscarId.Id_rol == IdAdmin);
                    _rol.Usuario = txtUsuario.Text;
                    _rol.Contraseña = txtContraseña.Text;
                    _rol.Id_Lector = IdLector;
                    _rol.Rol = 0;
                    _rol.estado = 1;
                    db.Entry(_rol).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.R.CargarDatos();
                    FrmPrincipal.Admin.CargarDatos();
                    Close();
                }
                else
                {
                    _rol = db.Roles.First(buscarId => buscarId.Id_rol == IdAdmin);
                    _rol.Usuario = txtUsuario.Text;
                    _rol.Contraseña = txtContraseña.Text;
                    _rol.Id_Lector = IdLector;
                    _rol.Rol = 1;
                    _rol.estado = 1;
                    db.Entry(_rol).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.R.CargarDatos();
                    FrmPrincipal.Admin.CargarDatos();
                    Close();
                }

            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            FrmBuscarLector lec = new FrmBuscarLector();
            lec.Indicador = 1;
            lec.ShowDialog();
        }

        int _mostrar;
        private void btnVerC_Click(object sender, EventArgs e)
        {
           
            if (_mostrar==0)
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
                _mostrar=0;
            }
            
        }
    }
}
