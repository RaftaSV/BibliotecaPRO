using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.principales
{
    public partial class FrmAutor : Form
    {
        public FrmAutor()
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
                                autores.Nombre,
                                Fecha_Nacimiento
                                = autores.fecha_nacimiento,
                                autores.Nacionalidad
                            };

                foreach (var i in lista)
                {
                    dgvAutores.Rows.Add(i.ID, i.Nombre, i.Nacionalidad, i.Fecha_Nacimiento);
                }


            }

        }

        public static FrmAutoresCrud Autor = new FrmAutoresCrud();

        private void btnNuevo_Click(object sender, EventArgs e)
        {


        }

        private void dgvAutores_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void Seleccionar()
        {
            string id = dgvAutores.CurrentRow.Cells[0].Value.ToString();
            string nombre = dgvAutores.CurrentRow.Cells[1].Value.ToString();
            string nacionalidad = dgvAutores.CurrentRow.Cells[2].Value.ToString();
            string fecha = dgvAutores.CurrentRow.Cells[3].Value.ToString();
            Autor.txtNacionalidad.Text = nacionalidad;
            Autor.txtNombre.Text = nombre;
            Autor.dtpFecha.Text = fecha;
            Autor.Id = int.Parse(id);
        }


        private void dgvAutores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAutores.Columns["NUEVO"].Index && e.RowIndex != -1)
            {
                Autor.btnGuardar.Show();
                Autor.btnEditar.Hide();
                Autor.btnEliminar.Hide();
                Autor.btnGuardar.Enabled = true;
                Autor.Limpiar();
                Autor.ShowDialog();
            }
            else if (e.ColumnIndex == dgvAutores.Columns["EDITAR"].Index && e.RowIndex != -1)
            {
                Seleccionar();
                Autor.btnGuardar.Hide();
                Autor.btnEliminar.Hide();
                Autor.btnEditar.Show();
                Autor.btnEditar.Enabled = true;
                Autor.ShowDialog();
            }
            else if (e.ColumnIndex == dgvAutores.Columns["ELIMINAR"].Index && e.RowIndex != -1)
            {
                Seleccionar();
                Autor.btnGuardar.Hide();
                Autor.btnEliminar.Show();
                Autor.btnEditar.Hide();
                Autor.btnEliminar.Enabled = true;
                Autor.dtpFecha.Enabled = false;
                Autor.txtNacionalidad.Enabled = false;
                Autor.txtNombre.Enabled = false;
                Autor.ShowDialog();
            }

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
