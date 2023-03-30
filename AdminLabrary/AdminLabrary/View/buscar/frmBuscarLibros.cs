using AdminLabrary.Model;
using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.formularios.principales;


namespace AdminLabrary.View.buscar
{
    public partial class frmBuscarLibros : Form
    {
        public frmBuscarLibros()
        {
            InitializeComponent();
           
        }

        private void frmBuscarLibros_Load(object sender, EventArgs e)
        {
            filtro();
        }

        void filtro()
        {

            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                dgvLibro.Rows.Clear();
                string buscar = txtBuscar.Text;
                var ListaLib = from Lib in db.Libros
                               from Aut in db.Autores where Lib.Id_autor == Aut.Id_autor
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
                                   Nombre = Lib.Nombre,
                                   Autor = Aut.Nombre,
                                   Cantidad = Lib.cantidad
                               };

                foreach (var iterar in ListaLib )
                {
                    dgvLibro.Rows.Add(iterar.Id, iterar.Nombre, iterar.Autor, iterar.Cantidad);
                }

            }

        }
        public int indicador;
        void seleccionar()
        {
            if (indicador == 0)
            {
                String Id = dgvLibro.CurrentRow.Cells[0].Value.ToString();
                String Nombre = dgvLibro.CurrentRow.Cells[1].Value.ToString();
                frmPrincipal.prestamos.alquiler.txtLibro.Text = Nombre;
                frmPrincipal.prestamos.alquiler.IdLibro = int.Parse(Id);
                Close();

            }
            else
            {
                String Id = dgvLibro.CurrentRow.Cells[0].Value.ToString();
                String Nombre = dgvLibro.CurrentRow.Cells[1].Value.ToString();
                frmPrincipal.Sol.solicitud.txtLibro.Text = Nombre;
                frmPrincipal.Sol.solicitud.idlibro = int.Parse(Id);
                Close();
            }

        }

        private void dgvLibro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionar();
        }

        private void dgvLibro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                seleccionar();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }
    }
}
