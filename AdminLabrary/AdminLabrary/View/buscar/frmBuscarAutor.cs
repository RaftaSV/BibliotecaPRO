using AdminLabrary.Model;
using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.formularios.principales;

namespace AdminLabrary.View.buscar
{
    public partial class frmBuscarAutor : Form
    {
        public frmBuscarAutor()
        {
            InitializeComponent();
            
        }

        private void frmBuscarAutor_Load(object sender, EventArgs e)
        {
            filtro();
        }

        void filtro()
        {
            using(BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                dgvAutor.Rows.Clear();
                string buscar = txtBuscar.Text;
                var ListaA = from AUT in db.Autores
                             where AUT.Nombre.Contains(buscar)
                             && AUT.estado ==0
                                select new 
                                {
                                    ID = AUT.Id_autor,
                                    Nombre = AUT.Nombre,
                                    Nacionalidad = AUT.Nacionalidad,
                                    Fecha_de_Nacimiento = AUT.fecha_nacimiento,
                                };
               foreach(var iterar in ListaA)
                {
                    dgvAutor.Rows.Add(iterar.ID, iterar.Nombre, iterar.Nacionalidad, iterar.Fecha_de_Nacimiento);
                }
            }

        }

      

        void seleccionar()
        {
            string Id = dgvAutor.CurrentRow.Cells[0].Value.ToString();
            string Nombre = dgvAutor.CurrentRow.Cells[1].Value.ToString();
            frmPrincipal.Lib.Libros.txtAutor.Text = Nombre;
            frmPrincipal.Lib.Libros.ID_Autor = int.Parse(Id);
            Close();
            
        }

        private void dgvAutor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                seleccionar();
            }else if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void dgvAutor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionar();

        }

        

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void dgvAutor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
