﻿using AdminLabrary.formularios.principales;
using AdminLabrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class frmLectorCRUD : Form
    {
        public string ID;
        public frmLectorCRUD()
        {
           
            InitializeComponent();
          
        }

        public void limpiar()
        {
            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtApellidos.Enabled = true;
            txtNombre.Enabled = true;
        }

        Lectores lector = new Lectores();
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtApellidos.Text !="" && txtNombre.Text != "") {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    lector.Nombres = txtNombre.Text;
                    lector.Apellidos = txtApellidos.Text;
                    lector.estado = 0;
                    db.Lectores.Add(lector);
                    db.SaveChanges();
                    limpiar();
                    frmPrincipal.lector.CargarDatos();
                    this.Close();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtApellidos.Text != "" && txtNombre.Text != "")
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    int id = int.Parse(ID);
                    lector = db.Lectores.Where(buscarid => buscarid.Id_Lector == id).First();
                    lector.Nombres = txtNombre.Text;
                    lector.Apellidos = txtApellidos.Text;
                    lector.estado = 0;
                    db.Entry(lector).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    limpiar();
                    frmPrincipal.lector.CargarDatos();
                    this.Close();
                }


            }
        }

        private void frmNuevoLector_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                int id = int.Parse(ID);
                lector = db.Lectores.Where(buscarid => buscarid.Id_Lector == id).First();
                lector.Nombres = txtNombre.Text;
                lector.Apellidos = txtApellidos.Text;
                lector.estado = 1;
                db.Entry(lector).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                limpiar();
                frmPrincipal.lector.CargarDatos();
                this.Close();

            }
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblApellidos_Click(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}
