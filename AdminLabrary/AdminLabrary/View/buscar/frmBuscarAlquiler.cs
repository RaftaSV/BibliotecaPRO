using AdminLabrary.Model;
using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.View.principales;

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
                Alquileres Alq = new Alquileres();
                Lectores Lec = new Lectores();
                Libros Lib = new Libros();
                dgvAlquiler.Rows.Clear();
                string buscar = txtBuscar.Text;
                if(rbtnLector.Checked)
                {
                    var listaA = from alq in db.Alquileres
                                 from lec in db.Lectores
                                 from lib in db.Libros
                                 from admi in db.Roles
                                 from admin in db.Roles
                                 where Alq.Entregado == admi.Id_rol
                                 where Alq.Recibido == admin.Id_rol
                                 where Lec.Id_Lector == Alq.Id_Lector
                                 where Alq.Id_libro == Lib.Id_libro
                                 where Alq.Recibido != null
                                 where Lec.Nombres.Contains(buscar)
                                 select new
                                 {
                                     ID = Alq.Id_alquiler,
                                     Lector = Lec.Nombres,
                                     Libro = Lib.Nombre,
                                     entregado = admi.Usuario,
                                     Cantidad = Alq.cantidad,
                                     Fecha_Entrega = Alq.fecha_de_entrega,
                                     Recibido = admin.Usuario
                                 };
                    foreach (var iterar in listaA)
                    {
                        dgvAlquiler.Rows.Add(iterar.ID, iterar.Lector, iterar.Libro, iterar.Cantidad, iterar.entregado, iterar.Fecha_Entrega, iterar.Recibido);
                    }
                }else if (rbtnLibro.Checked)
                {
                    var listaA = from alq in db.Alquileres
                                 from lec in db.Lectores
                                 from lib in db.Libros
                                 from admi in db.Roles
                                 from admin in db.Roles
                                 where Alq.Entregado == admi.Id_rol
                                 where Alq.Recibido == admin.Id_rol
                                 where Lec.Id_Lector == Alq.Id_Lector
                                 where Alq.Id_libro == Lib.Id_libro
                                 where Alq.Recibido != null
                                 where Lib.Nombre.Contains(buscar)
                                 select new
                                 {
                                     ID = Alq.Id_alquiler,
                                     Lector = Lec.Nombres,
                                     Libro = Lib.Nombre,
                                     entregado = admi.Usuario,
                                     Cantidad = Alq.cantidad,
                                     Fecha_Entrega = Alq.fecha_de_entrega,
                                     Recibido = admin.Usuario
                                 };
                    foreach (var iterar in listaA)
                    {
                        dgvAlquiler.Rows.Add(iterar.ID, iterar.Lector, iterar.Libro, iterar.Cantidad, iterar.entregado, iterar.Fecha_Entrega, iterar.Recibido);
                    }
                }
                else
                {
                    var listaA = from alq in db.Alquileres
                                 from lec in db.Lectores
                                 from lib in db.Libros
                                 from admi in db.Roles
                                 from admin in db.Roles
                                 where Alq.Entregado == admi.Id_rol
                                 where Alq.Recibido == admin.Id_rol
                                 where Lec.Id_Lector == Alq.Id_Lector
                                 where Alq.Id_libro == Lib.Id_libro
                                 where Alq.Recibido != null
                                 where admin.Usuario.Contains(buscar)
                                 select new
                                 {
                                     ID = Alq.Id_alquiler,
                                     Lector = Lec.Nombres,
                                     Libro = Lib.Nombre,
                                     entregado = admi.Usuario,
                                     Cantidad = Alq.cantidad,
                                     Fecha_Entrega = Alq.fecha_de_entrega,
                                     Recibido = admin.Usuario
                                 };
                    foreach (var iterar in listaA)
                    {
                        dgvAlquiler.Rows.Add(iterar.ID, iterar.Lector, iterar.Libro, iterar.Cantidad, iterar.entregado, iterar.Fecha_Entrega, iterar.Recibido);
                    }
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
