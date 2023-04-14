using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;

namespace AdminLabrary.View.principales
{
    public partial class FrmEditorial : Form
    {
        public FrmEditorial()
        {
            InitializeComponent();
        }

        private void FpEditoriales_Load(object sender, EventArgs e)
        {
            CargarDatos();


        }

        public void CargarDatos()
        {
            dgvEditorial.Rows.Clear();
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                var lista = from ed in db.Editoriales
                            where ed.estado==0
                            select new {ID = ed.Id_Editorial,
                                ed.Editorial,
                                ed.Fundada,
                                ed.Direccion };
               foreach(var i in lista)
                {
                    dgvEditorial.Rows.Add(i.ID, i.Editorial, i.Fundada, i.Direccion);
                }
            }

        }

        private void dgvEditorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public static FrmEditorialesCrud Editorial = new FrmEditorialesCrud();
       
        void Seleccionar()
        {
            int id = int.Parse(dgvEditorial.CurrentRow.Cells[0].Value.ToString());
            string edit = dgvEditorial.CurrentRow.Cells[1].Value.ToString();
            string fundada = dgvEditorial.CurrentRow.Cells[2].Value.ToString();
            string direccion = dgvEditorial.CurrentRow.Cells[3].Value.ToString();

            Editorial.txtDirecion.Text = direccion;
            Editorial.txtEditorial.Text = edit;
            Editorial.Id = id;
            Editorial.dtpFecha.Text = fundada;
        }

    

    



        private void dgvEditorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvEditorial.Columns["NUEVO"].Index && e.RowIndex != -1)
            {

                Editorial.btnGuardar.Enabled = true;
                Editorial.btnGuardar.Show();
                Editorial.btnEditar.Hide();
                Editorial.btnEliminar.Hide();
                Editorial.Limpiar();

                Editorial.ShowDialog();
            }
            else if (e.ColumnIndex == dgvEditorial.Columns["EDITAR"].Index && e.RowIndex != -1)
            {
                Seleccionar();
                Editorial.btnEditar.Enabled = true;
                Editorial.btnGuardar.Hide();
                Editorial.btnEditar.Show();
                Editorial.btnEliminar.Hide();
                Editorial.txtDirecion.Enabled = true;
                Editorial.txtEditorial.Enabled = true;
                Editorial.dtpFecha.Enabled = true;
                Editorial.ShowDialog();
            }
            else if (e.ColumnIndex == dgvEditorial.Columns["ELIMINAR"].Index && e.RowIndex != -1)
            {
                Seleccionar();
                Editorial.btnEliminar.Enabled = true;
                Editorial.btnGuardar.Hide();
                Editorial.btnEditar.Hide();
                Editorial.btnEliminar.Show();
                Editorial.txtDirecion.Enabled = false;
                Editorial.txtEditorial.Enabled = false;
                Editorial.dtpFecha.Enabled = false;
                Editorial.ShowDialog();
            }

        }

    }
}
    

