using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;



namespace AdminLabrary.formularios.principales
{
    public partial class frmLibros : Form
    {
        public frmLibros()
        {
            InitializeComponent();

        }



        private void frmLibros_Load(object sender, EventArgs e)
        {
            rbtnLibro.Checked = true;
            CargaDatos();
        }

        public void CargaDatos()
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                string buscar = txtBuscar.Text;
                dgvLibros.Rows.Clear();
                if (rbtnLibro.Checked == true)
                {
                    var lista = from li in db.Libros
                                from au in db.Autores
                                from ca in db.Categorias
                                from ed in db.Editoriales
                                where li.Id_categoria == ca.Id_categoria
                                && li.Id_autor == au.Id_autor
                                && li.Id_Editorial == ed.Id_Editorial
                                && li.estado == 0
                                && au.estado == 0
                                && ca.estado == 0
                                && ed.estado == 0
                                && li.Nombre.Contains(buscar)
                                select new
                                {
                                    ID = li.Id_libro,
                                    Nombre = li.Nombre,
                                    Cantidad = li.cantidad,
                                    Año = li.Año,
                                    Numero_edicion = li.Numero_edicion,
                                    Autor = au.Nombre,
                                    Editorial = ed.Editorial,
                                    Categoria = ca.Categoria,
                                    idAutor = li.Id_autor,
                                    idEditorial = li.Id_Editorial,
                                    idCategoria = ca.Id_categoria
                                };
                    foreach (var i in lista)
                    {
                        dgvLibros.Rows.Add(i.ID, i.Nombre, i.Cantidad, i.Año, i.Numero_edicion, i.Autor, i.Editorial, i.Categoria, i.idAutor, i.idEditorial, i.idCategoria);
                    }
                }
                else
                {
                    var lista = from li in db.Libros
                                from au in db.Autores
                                from ca in db.Categorias
                                from ed in db.Editoriales
                                where li.Id_categoria == ca.Id_categoria
                                && li.Id_autor == au.Id_autor
                                && li.Id_Editorial == ed.Id_Editorial
                                && li.estado == 0
                                && au.estado == 0
                                && ca.estado == 0
                                && ed.estado == 0
                                && au.Nombre.Contains(buscar)
                                select new
                                {
                                    ID = li.Id_libro,
                                    Nombre = li.Nombre,
                                    Cantidad = li.cantidad,
                                    Año = li.Año,
                                    Numero_edicion = li.Numero_edicion,
                                    Autor = au.Nombre,
                                    Editorial = ed.Editorial,
                                    Categoria = ca.Categoria,
                                    idAutor = li.Id_autor,
                                    idEditorial = li.Id_Editorial,
                                    idCategoria = ca.Id_categoria
                                };
                    foreach (var i in lista)
                    {
                        dgvLibros.Rows.Add(i.ID, i.Nombre, i.Cantidad, i.Año, i.Numero_edicion, i.Autor, i.Editorial, i.Categoria, i.idAutor, i.idEditorial, i.idCategoria);
                    }
                }



            }

        }

        public frmLibrosCRUD Libros = new frmLibrosCRUD();
       

        private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    
        void seleccionar()
        {
            int Id = int.Parse(dgvLibros.CurrentRow.Cells[0].Value.ToString());
            int Id_autor = int.Parse(dgvLibros.CurrentRow.Cells[8].Value.ToString());
            int Id_Editorial = int.Parse(dgvLibros.CurrentRow.Cells[9].Value.ToString());
            string Id_Categoria = (dgvLibros.CurrentRow.Cells[10].Value.ToString());
            string autor = dgvLibros.CurrentRow.Cells[5].Value.ToString();
            string editorial = dgvLibros.CurrentRow.Cells[6].Value.ToString();
            string nombre = dgvLibros.CurrentRow.Cells[1].Value.ToString();
            string cantidad = dgvLibros.CurrentRow.Cells[2].Value.ToString();
            string año = dgvLibros.CurrentRow.Cells[3].Value.ToString();
            string numero = dgvLibros.CurrentRow.Cells[4].Value.ToString();

            Libros.txtAutor.Text = autor;
            Libros.txtEditorial.Text = editorial;
            Libros.txtNombre.Text = nombre;
            Libros.txtCantidad.Text = cantidad;
            Libros.dtpAño.Text = año;
            Libros.txtNumero_de_Edicion.Text = numero;
            Libros.ID_Libro = Id;
            Libros.ID_Autor = Id_autor;
            Libros.ID_Editorial = Id_Editorial;
            Libros.ID_Cate = Id_Categoria;
            Libros.id = int.Parse(Id_Categoria) - 1;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLibros.RowCount > 0)
            {

            }

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargaDatos();
        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                if (e.ColumnIndex == dgvLibros.Columns["NUEVO"].Index && e.RowIndex != -1)
                {
                    Libros.btnGuardar.Show();
                    Libros.btnGuardar.Enabled = true;
                    Libros.btnActualizar.Hide();
                    Libros.btnEliminar.Hide();
                    Libros.limpiar();
                    Libros.indi = 0;
                    Libros.ShowDialog();
                }
                else if (e.ColumnIndex == dgvLibros.Columns["EDITAR"].Index && e.RowIndex != -1)
                {
                    Libros.btnGuardar.Hide();
                    Libros.btnActualizar.Show();
                    Libros.btnActualizar.Enabled = true;
                    Libros.btnEliminar.Hide();
                    Libros.indi = 0;
                    seleccionar();
                    Libros.ShowDialog();
                }
                else if (e.ColumnIndex == dgvLibros.Columns["ELIMINAR"].Index && e.RowIndex != -1)
                {
                    Libros.btnGuardar.Hide();
                    Libros.btnActualizar.Hide();
                    Libros.btnSeleccionarA.Hide();
                    Libros.btnSeleccionarE.Hide();
                    Libros.btnEliminar.Show();
                    Libros.btnEliminar.Enabled = true;
                    Libros.indi = 1;
                    seleccionar();
                    Libros.ShowDialog();
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rbtnAutor_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    }

