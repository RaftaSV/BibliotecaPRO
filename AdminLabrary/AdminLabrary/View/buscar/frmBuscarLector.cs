using AdminLabrary.Model;
using AdminLabrary.View.principales;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.buscar
{
    public partial class FrmBuscarLector : Form
    {
        public int Indicador = 1;
        public FrmBuscarLector()
        {
            InitializeComponent();
        }


        private void frmBuscarLector_Load(object sender, EventArgs e)
        {
            Filtro();

        }
        public void Filtro()
        {
            if (Indicador == 1)
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {

                    dgvLecto.Rows.Clear();
                    string buscar = txtBuscar.Text;
                    var listaL = from lec in db.Lectores
                                 where !(from adm in db.Roles select adm.Id_Lector).Contains(lec.Id_Lector)
                                 && lec.Nombres.Contains(buscar)
                                 && lec.estado == 0
                                 select new
                                 {
                                     ID = lec.Id_Lector,
                                     lec.Nombres,
                                     lec.Apellidos
                                 };
                    foreach (var i in listaL)
                    {

                        dgvLecto.Rows.Add(i.ID, i.Nombres, i.Apellidos);
                    }

                }
            }
            else if (Indicador == 2)
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    dgvLecto.Rows.Clear();
                    string buscar = txtBuscar.Text;
                    var listaL = from lec in db.Lectores
                                 where lec.Nombres.Contains(buscar)
                                  && lec.estado == 0
                                 select new
                                 {
                                     ID = lec.Id_Lector,
                                     lec.Nombres,
                                     lec.Apellidos
                                 };
                    foreach (var i in listaL)
                    {
                        int cantidad = 0;
                        var lista = from pres in db.Alquileres
                                    where pres.Id_Lector == i.ID
                                    && pres.Recibido == null
                                    select new
                                    {
                                        pres.cantidad
                                    };
                        foreach (var it in lista)
                        {
                            cantidad += it.cantidad;
                        }
                        if (cantidad < 3)
                        {
                            dgvLecto.Rows.Add(i.ID, i.Nombres, i.Apellidos, cantidad);
                        }
                    }

                }

            }
            else
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {

                    dgvLecto.Rows.Clear();
                    string buscar = txtBuscar.Text;
                    var listaL = from lec in db.Lectores
                                 where lec.Nombres.Contains(buscar)
                                 && lec.estado == 0
                                 select new
                                 {
                                     ID = lec.Id_Lector,
                                     lec.Nombres,
                                     lec.Apellidos
                                 };
                    foreach (var i in listaL)
                    {

                        dgvLecto.Rows.Add(i.ID, i.Nombres, i.Apellidos);
                    }

                }
            }
        }


        void Seleccionar()
        {

            if (Indicador == 1)
            {
                string id = dgvLecto.CurrentRow.Cells[0].Value.ToString();
                string nombre = dgvLecto.CurrentRow.Cells[1].Value.ToString();
                FrmPrincipal.Admin.Admin.txtLector.Text = nombre;
                FrmPrincipal.Admin.Admin.IdLector = int.Parse(id);
                FrmPrincipal.R.Admin.txtLector.Text = nombre;
                FrmPrincipal.R.Admin.IdLector = int.Parse(id);
                Close();
            }
            else if (Indicador == 2)
            {
                string idl = dgvLecto.CurrentRow.Cells[0].Value.ToString();
                string nombrel = dgvLecto.CurrentRow.Cells[1].Value.ToString();
                FrmPrincipal.Prestamos.Alquiler.Cantidad = 3 - int.Parse(dgvLecto.CurrentRow.Cells[3].Value.ToString());
                FrmPrincipal.Prestamos.Alquiler.txtCantidad.Text = (3 - int.Parse(dgvLecto.CurrentRow.Cells[3].Value.ToString())).ToString();
                FrmPrincipal.Prestamos.Alquiler.txtLector.Text = nombrel;
                FrmPrincipal.Prestamos.Alquiler.IdLector = int.Parse(idl);
                Close();
            }
            else
            {
                string idl = dgvLecto.CurrentRow.Cells[0].Value.ToString();
                string nombrel = dgvLecto.CurrentRow.Cells[1].Value.ToString();
                FrmPrincipal.Sol.Solicitud.txtLector.Text = nombrel;
                FrmPrincipal.Sol.Solicitud.Idlector = int.Parse(idl);
                Close();
            }
        }




        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Filtro();
        }

        private void dgvLecto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }

        private void dgvLecto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Seleccionar();
            }
        }

        private void dgvLecto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
