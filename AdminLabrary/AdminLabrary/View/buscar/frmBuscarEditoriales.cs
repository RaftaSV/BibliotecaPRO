using AdminLabrary.formularios.principales;
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
    public partial class frmBuscarEditoriales : Form
    {
        public frmBuscarEditoriales()
        {
            InitializeComponent();
            filtro();
        }

        private void frmBuscarEditoriales_Load(object sender, EventArgs e)
        {

        }

        void filtro()
        {
            using(BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                dgvEditorial.Rows.Clear();
                string buscar = txtBuscar.Text;
                var ListaE = from Edit in db.Editoriales
                             where Edit.Editorial.Contains(buscar)
                             && Edit.estado ==0
                             select new
                             {
                                 ID = Edit.Id_Editorial,
                                 Editorial = Edit.Editorial,
                                 Fundada = Edit.Fundada,
                                 Direccion = Edit.Direccion
                             };
                foreach (var iterar in ListaE)
                {
                    dgvEditorial.Rows.Add(iterar.ID, iterar.Editorial, iterar.Fundada, iterar.Direccion);
                }

            }
        }
    
        void seleccionar()
        {
            string Id = dgvEditorial.CurrentRow.Cells[0].Value.ToString();
            string Nombre = dgvEditorial.CurrentRow.Cells[1].Value.ToString();

            frmPrincipal.Lib.Libros.txtEditorial.Text = Nombre;
            frmPrincipal.Lib.Libros.ID_Editorial = int.Parse(Id);
            this.Close();




        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void dgvEditorial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionar();
        }

        private void dgvEditorial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                seleccionar();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dgvEditorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
