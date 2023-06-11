using AdminLabrary.Model;
using AdminLabrary.View.principales;
using System;
using System.Linq;
using System.Windows.Forms;


namespace AdminLabrary.View.buscar
{
    public partial class FrmBuscarLibros : Form
    {
        public FrmBuscarLibros()
        {
            InitializeComponent();

        }

        private void frmBuscarLibros_Load(object sender, EventArgs e)
        {
            Filtro();
        }

        void Filtro()
        {

            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                dgvLibro.Rows.Clear();
                string buscar = txtBuscar.Text;
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
                            && li.cantidad > 0
                            && li.Nombre.Contains(buscar)
                            select new
                            {
                                ID = li.Id_libro,
                                li.Nombre,
                                Cantidad = li.cantidad,
                                li.Año,
                                li.Numero_edicion,
                                Autor = au.Nombre,
                                ed.Editorial,
                                ca.Categoria,
                                idAutor = li.Id_autor,
                                idEditorial = li.Id_Editorial,
                                idCategoria = ca.Id_categoria
                            };
                foreach (var iterar in lista)
                {
                    dgvLibro.Rows.Add(iterar.ID, iterar.Nombre, iterar.Autor, iterar.Cantidad);
                }
              
             

            }

        }
        public int Indicador;
        void Seleccionar()
        {
            if (Indicador == 0)
            {
                String id = dgvLibro.CurrentRow.Cells[0].Value.ToString();
                String nombre = dgvLibro.CurrentRow.Cells[1].Value.ToString();
                FrmPrincipal.Prestamos.Alquiler.txtLibro.Text = nombre;
                FrmPrincipal.Prestamos.Alquiler.IdLibro = int.Parse(id);
                Close();

            }
            else
            {
                String id = dgvLibro.CurrentRow.Cells[0].Value.ToString();
                String nombre = dgvLibro.CurrentRow.Cells[1].Value.ToString();
                FrmPrincipal.Sol.Solicitud.txtLibro.Text = nombre;
                FrmPrincipal.Sol.Solicitud.Idlibro = int.Parse(id);
                Close();
            }

        }

        private void dgvLibro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }

        private void dgvLibro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Seleccionar();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Filtro();
        }
    }
}
