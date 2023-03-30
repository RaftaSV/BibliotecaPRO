using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;

namespace AdminLabrary.formularios.principales
{
    public partial class frmAutor : Form
    {
        public frmAutor()
        {
            InitializeComponent();
        }

        private void FpAutor_Load(object sender, EventArgs e)
        {
            CargarDatos();



        }

        public void CargarDatos()
        {
            dgvAutores.Rows.Clear();
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                var lista = from autores in db.Autores
                            where autores.estado == 0
                            select new
                            {
                                ID = autores.Id_autor,
                                Nombre = autores.Nombre,
                                Fecha_Nacimiento
                                = autores.fecha_nacimiento,
                                Nacionalidad = autores.Nacionalidad
                            };

                foreach (var i in lista)
                {
                    dgvAutores.Rows.Add(i.ID, i.Nombre, i.Nacionalidad, i.Fecha_Nacimiento);
                }

               
            }

        }

        public static frmAutoresCRUD autor = new frmAutoresCRUD();

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            

        }

        private void dgvAutores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        void seleccionar()
        {
            string id = dgvAutores.CurrentRow.Cells[0].Value.ToString();
            string nombre = dgvAutores.CurrentRow.Cells[1].Value.ToString();
            string nacionalidad = dgvAutores.CurrentRow.Cells[2].Value.ToString();
            string fecha = dgvAutores.CurrentRow.Cells[3].Value.ToString();
            autor.txtNacionalidad.Text = nacionalidad;
            autor.txtNombre.Text = nombre;
            autor.dtpFecha.Text = fecha;
            autor.ID = int.Parse(id);
        }

     
        private void dgvAutores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAutores.Columns["NUEVO"].Index && e.RowIndex != -1)
            {
                autor.btnGuardar.Show();
                autor.btnEditar.Hide();
                autor.btnEliminar.Hide();
                autor.btnGuardar.Enabled = true;
                autor.limpiar();
                autor.ShowDialog();
            }
            else if (e.ColumnIndex == dgvAutores.Columns["EDITAR"].Index && e.RowIndex != -1)
            {
                seleccionar();
                autor.btnGuardar.Hide();
                autor.btnEliminar.Hide();
                autor.btnEditar.Show();
                autor.btnEditar.Enabled = true;
                autor.ShowDialog();
            }
            else if (e.ColumnIndex == dgvAutores.Columns["ELIMINAR"].Index && e.RowIndex != -1)
            {
                seleccionar();
                autor.btnGuardar.Hide();
                autor.btnEliminar.Show();
                autor.btnEditar.Hide();
                autor.btnEliminar.Enabled = true;
                autor.dtpFecha.Enabled = false;
                autor.txtNacionalidad.Enabled = false;
                autor.txtNombre.Enabled = false;
                autor.ShowDialog();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAutores.RowCount > 0)
            {
                
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
