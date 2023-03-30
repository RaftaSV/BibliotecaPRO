
using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;


namespace AdminLabrary.formularios.principales
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
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
                            where cat.estado ==0
                            select new {ID = cat.Id_categoria,Categoria =cat.Categoria };

                foreach( var i in lista) {
                    dgvCat.Rows.Add(i.ID,i.Categoria);
                }
              
                
            }

        }
        void seleccionar()
        {
            int Id = int.Parse(dgvCat.CurrentRow.Cells[0].Value.ToString());
            string cate = dgvCat.CurrentRow.Cells[1].Value.ToString();
            categoria.txtCategoria.Text = cate;
            categoria.ID = Id;
        }

        private void dgvCat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        frmCategoriasCRUD categoria = new frmCategoriasCRUD();


        private void dgvCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCat.Columns["NUEVO"].Index && e.RowIndex != -1)
            {
                categoria.btnGuardar.Show();
                categoria.btnEditar.Hide();
                categoria.btnEliminar.Hide();
                categoria.btnGuardar.Enabled = true;
                categoria.limpiar();
                categoria.ShowDialog();
            }
            else if (e.ColumnIndex == dgvCat.Columns["EDITAR"].Index && e.RowIndex != -1)
            {
                seleccionar();
                categoria.btnEditar.Enabled = true;
                categoria.btnGuardar.Hide();
                categoria.btnEditar.Show();
                categoria.btnEliminar.Hide();
                categoria.ShowDialog();
            }
            else if (e.ColumnIndex == dgvCat.Columns["ELIMINAR"].Index && e.RowIndex != -1)
            {
                seleccionar();
                categoria.btnEliminar.Enabled = true;
                categoria.btnGuardar.Hide();
                categoria.btnEditar.Hide();
                categoria.btnEliminar.Show();
                categoria.txtCategoria.Enabled = false;
                categoria.ShowDialog();
            }

        }

    }
}
    

