using AdminLabrary.Model;
using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.View.principales;


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
                Libros Lib = new Libros();
                Autores Aut = new Autores();
                    string buscar = txtBuscar.Text;
                var listaLib = from lib in db.Libros
                               from aut in db.Autores where Lib.Id_autor == Aut.Id_autor
                               from ca in db.Categorias where Lib.Id_categoria == ca.Id_categoria
                               from ed in db.Editoriales where Lib.Id_Editorial == ed.Id_Editorial
                               where Lib.Nombre.Contains(buscar)
                               where Lib.cantidad > 0
                               && Lib.estado==0
                               && Aut.estado == 0
                               && ca.estado == 0
                               && ed.estado == 0
                               select new
                               {
                                   Id = Lib.Id_libro,
                                   Lib.Nombre,
                                   Autor = Aut.Nombre,
                                   Cantidad = Lib.cantidad
                               };

                foreach (var iterar in listaLib )
                {
                    dgvLibro.Rows.Add(iterar.Id, iterar.Nombre, iterar.Autor, iterar.Cantidad);
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
