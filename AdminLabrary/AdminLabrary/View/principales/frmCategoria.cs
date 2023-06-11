using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.principales
{
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FpCategoria_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        public void CargarDatos()
        {
            dgvCat.Rows.Clear();
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                var lista = from cat in db.Categorias
                            where cat.estado == 0
                            select new { ID = cat.Id_categoria, cat.Categoria };

                foreach (var i in lista)
                {
                    dgvCat.Rows.Add(i.ID, i.Categoria);
                }


            }

        }
        void Seleccionar()
        {
            int id = int.Parse(dgvCat.CurrentRow.Cells[0].Value.ToString());
            string cate = dgvCat.CurrentRow.Cells[1].Value.ToString();
            _categoria.txtCategoria.Text = cate;
            _categoria.Id = id;
        }

        private void dgvCat_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        FrmCategoriasCrud _categoria = new FrmCategoriasCrud();


        private void dgvCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCat.Columns["NUEVO"].Index && e.RowIndex != -1)
            {
                _categoria.btnGuardar.Show();
                _categoria.btnEditar.Hide();
                _categoria.btnEliminar.Hide();
                _categoria.btnGuardar.Enabled = true;
                _categoria.Limpiar();
                _categoria.ShowDialog();
            }
            else if (e.ColumnIndex == dgvCat.Columns["EDITAR"].Index && e.RowIndex != -1)
            {
                Seleccionar();
                _categoria.btnEditar.Enabled = true;
                _categoria.btnGuardar.Hide();
                _categoria.btnEditar.Show();
                _categoria.btnEliminar.Hide();
                _categoria.ShowDialog();
            }
            else if (e.ColumnIndex == dgvCat.Columns["ELIMINAR"].Index && e.RowIndex != -1)
            {
                Seleccionar();
                _categoria.btnEliminar.Enabled = true;
                _categoria.btnGuardar.Hide();
                _categoria.btnEditar.Hide();
                _categoria.btnEliminar.Show();
                _categoria.txtCategoria.Enabled = false;
                _categoria.ShowDialog();
            }

        }

    }
}


