using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.principales
{
    public partial class FrmLectores : Form
    {
        public FrmLectores()
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
                dgvLectores.Rows.Clear();
                var lista = from lec in db.Lectores
                            where lec.estado == 0
                            select new
                            {
                                ID = lec.Id_Lector,
                                Nombre = lec.Nombres,
                                lec.Apellidos

                            };
                foreach (var i in lista)
                {
                    dgvLectores.Rows.Add(i.ID, i.Nombre, i.Apellidos);
                }
            }

        }

        FrmLectorCrud _nuevo = new FrmLectorCrud();


        private void Seleccionar()
        {
            string id = dgvLectores.CurrentRow.Cells[0].Value.ToString();
            string nombre = dgvLectores.CurrentRow.Cells[1].Value.ToString();
            string apellido = dgvLectores.CurrentRow.Cells[2].Value.ToString();
            _nuevo.Id = id;
            _nuevo.txtNombre.Text = nombre;
            _nuevo.txtApellidos.Text = apellido;
        }



        private void dgvLectores_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvLectores.Columns["NUEV"].Index && e.RowIndex != -1)
            {
                _nuevo.Limpiar();
                _nuevo.btnGuardar.Show();
                _nuevo.btnEditar.Hide();
                _nuevo.btnEliminar.Hide();
                _nuevo.btnGuardar.Enabled = true;

                _nuevo.ShowDialog();
            }
            else if (e.ColumnIndex == dgvLectores.Columns["EDITAR"].Index && e.RowIndex != -1)
            {
                Seleccionar();
                _nuevo.btnGuardar.Hide();
                _nuevo.btnEditar.Show();
                _nuevo.btnEliminar.Hide();
                _nuevo.btnEditar.Enabled = true;

                _nuevo.ShowDialog();
            }
            else if (e.ColumnIndex == dgvLectores.Columns["ELIMINAR"].Index && e.RowIndex != -1)
            {
                _nuevo.btnGuardar.Hide();
                _nuevo.btnEditar.Hide();
                _nuevo.btnEliminar.Show();
                _nuevo.btnEliminar.Enabled = true;
                _nuevo.txtNombre.Enabled = false;
                _nuevo.txtApellidos.Enabled = false;
                Seleccionar();
                _nuevo.ShowDialog();
            }

        }

        private void dgvLectores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
