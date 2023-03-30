
using System;
using System.Linq;
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
                dgvLectores.Rows.Clear();
                var lista = from lec in db.Lectores
                             where lec.estado == 0
                            select new
                            {
                                ID = lec.Id_Lector,Nombre=lec.Nombres, Apellidos = lec.Apellidos
                                
                            };
              foreach(var i in lista)
                {
                    dgvLectores.Rows.Add(i.ID, i.Nombre, i.Apellidos);
                }
            }

        }

        frmLectorCRUD nuevo = new frmLectorCRUD();
     

        private void seleccionar()
        {
            string id = dgvLectores.CurrentRow.Cells[0].Value.ToString();
            string nombre = dgvLectores.CurrentRow.Cells[1].Value.ToString();
            string apellido = dgvLectores.CurrentRow.Cells[2].Value.ToString();
            nuevo.ID = id;
            nuevo.txtNombre.Text = nombre;
            nuevo.txtApellidos.Text = apellido;
        }

       

        private void dgvLectores_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvLectores.Columns["NUEV"].Index && e.RowIndex != -1)
            {
                nuevo.limpiar();
                nuevo.btnGuardar.Show();
                nuevo.btnEditar.Hide();
                nuevo.btnEliminar.Hide();
                nuevo.btnGuardar.Enabled = true;

                nuevo.ShowDialog();
            }
            else if (e.ColumnIndex == dgvLectores.Columns["EDITAR"].Index && e.RowIndex != -1)
            {
                seleccionar();
                nuevo.btnGuardar.Hide();
                nuevo.btnEditar.Show();
                nuevo.btnEliminar.Hide();
                nuevo.btnEditar.Enabled = true;

                nuevo.ShowDialog();
            }
            else if (e.ColumnIndex == dgvLectores.Columns["ELIMINAR"].Index && e.RowIndex != -1)
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

        private void dgvLectores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
