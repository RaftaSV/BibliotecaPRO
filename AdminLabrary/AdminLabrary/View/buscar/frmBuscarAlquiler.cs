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

namespace AdminLabrary.View.buscar
{
    public partial class frmBuscarAlquiler : Form
    {
        public frmBuscarAlquiler()
        {
            InitializeComponent();
        }

        private void frmBuscarAlquiler_Load(object sender, EventArgs e)
        {
            filtro();
        }

        void filtro()
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                dgvAlquiler.Rows.Clear();
                string buscar = txtBuscar.Text;
                var ListaA = from Alq in db.Alquileres
                             from Lec in db.Roles
                             from Lib in db.Libros
                             from admi in db.Roles
                             from admin in db.Roles
                             from lect in db.Lectores
                             where Alq.Entregado == admi.Id_rol
                             where Alq.Recibido == admin.Id_rol
                             where Lec.Id_rol == Alq.Id_Lector
                             where Alq.Id_libro == Lib.Id_libro
                             where lect.Id_Lector == Lec.Id_Lector
                             where Alq.Recibido != null
                             where lect.Nombres.Contains(buscar)
                             select new
                             {
                                 ID = Alq.Id_alquiler,
                                 Lector = lect.Nombres,
                                 Libro = Lib.Nombre,
                                 entregado = admi.Usuario,
                                 Cantidad = Alq.cantidad,
                                 Fecha_Entrega = Alq.fecha_de_entrega,
                                 Recibido = admin.Usuario
                             };
                foreach (var iterar in ListaA)
                {
                    dgvAlquiler.Rows.Add(iterar.ID, iterar.Lector, iterar.Libro,iterar.Cantidad,iterar.entregado,  iterar.Fecha_Entrega, iterar.Recibido);
                }
            }
        }

        public int indicador;
        void seleccionar()
        {
            string Id = dgvAlquiler.CurrentRow.Cells[0].Value.ToString();
            string Nombre = dgvAlquiler.CurrentRow.Cells[1].Value.ToString();
            if (indicador == 1)
            {
                frmPrincipal.admin.admin.txtLector.Text = Nombre;
                frmPrincipal.admin.admin.IDLector = int.Parse(Id);
                this.Close();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void dgvAlquiler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionar();
        }

        private void dgvAlquiler_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                seleccionar();
            }
        }
    }
}
