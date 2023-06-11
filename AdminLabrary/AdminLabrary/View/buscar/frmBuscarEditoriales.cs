using AdminLabrary.Model;
using AdminLabrary.View.principales;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.buscar
{
    public partial class FrmBuscarEditoriales : Form
    {
        public FrmBuscarEditoriales()
        {
            InitializeComponent();
            Filtro();
        }

        private void frmBuscarEditoriales_Load(object sender, EventArgs e)
        {

        }

        void Filtro()
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                dgvEditorial.Rows.Clear();
                string buscar = txtBuscar.Text;
                var listaE = from edit in db.Editoriales
                             where edit.Editorial.Contains(buscar)
                             && edit.estado == 0
                             select new
                             {
                                 ID = edit.Id_Editorial,
                                 edit.Editorial,
                                 edit.Fundada,
                                 edit.Direccion
                             };
                foreach (var iterar in listaE)
                {
                    dgvEditorial.Rows.Add(iterar.ID, iterar.Editorial, iterar.Fundada, iterar.Direccion);
                }

            }
        }

        void Seleccionar()
        {
            string id = dgvEditorial.CurrentRow.Cells[0].Value.ToString();
            string nombre = dgvEditorial.CurrentRow.Cells[1].Value.ToString();

            FrmPrincipal.Lib.Libros.txtEditorial.Text = nombre;
            FrmPrincipal.Lib.Libros.IdEditorial = int.Parse(id);
            Close();




        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Filtro();
        }

        private void dgvEditorial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }

        private void dgvEditorial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Seleccionar();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
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
