using AdminLabrary.Model;
using AdminLabrary.View.principales;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.buscar
{
    public partial class FrmBuscarAutor : Form
    {
        public FrmBuscarAutor()
        {
            InitializeComponent();

        }

        private void frmBuscarAutor_Load(object sender, EventArgs e)
        {
            Filtro();
        }

        void Filtro()
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                dgvAutor.Rows.Clear();
                string buscar = txtBuscar.Text;
                var listaA = from aut in db.Autores
                             where aut.Nombre.Contains(buscar)
                             && aut.estado == 0
                             select new
                             {
                                 ID = aut.Id_autor,
                                 aut.Nombre,
                                 aut.Nacionalidad,
                                 Fecha_de_Nacimiento = aut.fecha_nacimiento,
                             };
                foreach (var iterar in listaA)
                {
                    dgvAutor.Rows.Add(iterar.ID, iterar.Nombre, iterar.Nacionalidad, iterar.Fecha_de_Nacimiento);
                }
            }

        }



        void Seleccionar()
        {
            string id = dgvAutor.CurrentRow.Cells[0].Value.ToString();
            string nombre = dgvAutor.CurrentRow.Cells[1].Value.ToString();
            FrmPrincipal.Lib.Libros.txtAutor.Text = nombre;
            FrmPrincipal.Lib.Libros.IdAutor = int.Parse(id);
            Close();

        }

        private void dgvAutor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Seleccionar();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void dgvAutor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();

        }





        private void dgvAutor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
