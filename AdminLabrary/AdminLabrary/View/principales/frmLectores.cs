﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;

namespace AdminLabrary.formularios.principales
{
    public partial class frmLectores : Form
    {
        public frmLectores()
        {
            InitializeComponent();
        }


        private void frmLectores_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        public void CargarDatos()
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                var lista = from lec in db.Lectores
                             where lec.estado == 0
                            select new
                            {
                                ID = lec.Id_Lector,Nombre=lec.Nombres, Apellidos = lec.Apellidos
                                
                            };
                dgvLectores.DataSource = lista.ToList();
            }

        }

        frmLectorCRUD nuevo = new frmLectorCRUD();
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo.limpiar();
            nuevo.btnGuardar.Show();
            nuevo.btnEditar.Hide();
            nuevo.btnEliminar.Hide();
            nuevo.btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            nuevo.ShowDialog();
        }

        private void seleccionar()
        {
            string id = dgvLectores.CurrentRow.Cells[0].Value.ToString();
            string nombre = dgvLectores.CurrentRow.Cells[1].Value.ToString();
            string apellido = dgvLectores.CurrentRow.Cells[2].Value.ToString();
            nuevo.ID = id;
            nuevo.txtNombre.Text = nombre;
            nuevo.txtApellidos.Text = apellido;
        }

        private void dgvLectores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLectores.RowCount > 0)
            {
                seleccionar();
                nuevo.btnGuardar.Hide();
                nuevo.btnEditar.Show();
                nuevo.btnEliminar.Hide();
                nuevo.btnEditar.Enabled = true;
                btnEliminar.Enabled = false;
                btnEditar.Enabled = false;
                nuevo.ShowDialog();
            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLectores.RowCount > 0)
            {
                nuevo.btnGuardar.Hide();
                nuevo.btnEditar.Hide();
                nuevo.btnEliminar.Show();
                nuevo.btnEliminar.Enabled = true;
                nuevo.txtNombre.Enabled = false;
                nuevo.txtApellidos.Enabled = false;
                seleccionar();
                nuevo.ShowDialog();
            }
           
        }
    }
}
