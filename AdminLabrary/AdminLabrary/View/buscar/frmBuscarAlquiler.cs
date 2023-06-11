using AdminLabrary.Model;
using AdminLabrary.View.principales;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.buscar
{
    public partial class FrmBuscarAlquiler : Form
    {
        public FrmBuscarAlquiler()
        {
            InitializeComponent();
        }

        private void frmBuscarAlquiler_Load(object sender, EventArgs e)
        {
            Filtro();
            rbtnLector.Checked = true;
        }

        void Filtro()
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                dgvAlquiler.Rows.Clear();
                string buscar = txtBuscar.Text;
                var query = from alq in db.Alquileres
                            join lec in db.Lectores on alq.Id_Lector equals lec.Id_Lector
                            join lib in db.Libros on alq.Id_libro equals lib.Id_libro
                            join admi in db.Roles on alq.Entregado equals admi.Id_rol
                            join admin in db.Roles on alq.Recibido equals admin.Id_rol
                            where alq.Recibido != null
                            select new
                            {
                                ID = alq.Id_alquiler,
                                Lector = lec.Nombres,
                                Libro = lib.Nombre,
                                entregado = admi.Usuario,
                                Cantidad = alq.cantidad,
                                Fecha_Entrega = alq.fecha_de_entrega,
                                Recibido = admin.Usuario
                            };

                if (rbtnLector.Checked)
                {
                    query = query.Where(lec => lec.Lector.Contains(buscar));
                }
                else if (rbtnLibro.Checked)
                {
                    query = query.Where(lib => lib.Libro.Contains(buscar));
                }
                else
                {
                    query = query.Where(admin => admin.Recibido.Contains(buscar));
                }

                foreach (var iterar in query)
                {
                    dgvAlquiler.Rows.Add(iterar.ID, iterar.Lector, iterar.Libro, iterar.Cantidad, iterar.entregado, iterar.Fecha_Entrega, iterar.Recibido);
                }
            }
        }


        public int Indicador;
        void Seleccionar()
        {
            string id = dgvAlquiler.CurrentRow.Cells[0].Value.ToString();
            string nombre = dgvAlquiler.CurrentRow.Cells[1].Value.ToString();
            if (Indicador == 1)
            {
                FrmPrincipal.Admin.Admin.txtLector.Text = nombre;
                FrmPrincipal.Admin.Admin.IdLector = int.Parse(id);
                Close();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Filtro();
        }

        private void dgvAlquiler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }

        private void dgvAlquiler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Seleccionar();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
