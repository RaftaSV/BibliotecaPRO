using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.principales
{
    public partial class FrmSolicitudes : Form
    {
        public FrmSolicitudes()
        {
            InitializeComponent();

        }
        public int Loging;
        public int Id;

        public void CargarDatos()
        {
            Libros Lib = new Libros();
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                dgvSolicitudes.Rows.Clear();
                if (Loging == 0)
                {
                    var lista = from solic in db.solicitudes
                                from lec in db.Lectores
                                from lib in db.Libros

                                where solic.id_lector == Id
                                where solic.id_lector == lec.Id_Lector
                                where solic.libros == Lib.Id_libro
                                where solic.estado == 0
                                select new
                                {
                                    ID = solic.id_soli,
                                    Lector = lec.Nombres,
                                    Libros = Lib.Nombre,
                                    solic.Cantidad,
                                    Estado = solic.estado,
                                    lec.Id_Lector,
                                    Id_Libro = solic.libros

                                };

                    foreach (var iterar in lista)
                    {
                        if (iterar.Estado == 0)
                        {
                            dgvSolicitudes.Rows.Add(iterar.ID, iterar.Lector, iterar.Libros, iterar.Cantidad,
                            iterar.Id_Lector, iterar.Id_Libro);
                            
                        }
                    }

                    lblMessage.Visible = !lista.Any();
                }
                else if (Loging == 1)
                {
                    Lectores Lec = new Lectores();
                    var lista = from solic in db.solicitudes
                                from lec in db.Lectores
                                from lib in db.Libros
                                where solic.estado == 0
                                where solic.id_lector == Lec.Id_Lector
                                where solic.libros == Lib.Id_libro
                                select new
                                {
                                    ID = solic.id_soli,
                                    Lector = Lec.Nombres,
                                    Libros = Lib.Nombre,
                                    solic.Cantidad,
                                    Estado = solic.estado,
                                    Id_Lector = solic.id_lector,
                                    Id_Libro = solic.libros

                                };

                    foreach (var iterar in lista)
                    {
                        if (iterar.Estado == 0)
                        {
                            dgvSolicitudes.Rows.Add(iterar.ID, iterar.Lector, iterar.Libros, iterar.Cantidad,
                            iterar.Id_Lector, iterar.Id_Libro);
                           
                        }
                    }
                    lblMessage.Visible = !lista.Any();
                }
            }

        }

        public void Seleccionar()
        {
            int id = int.Parse(dgvSolicitudes.CurrentRow.Cells[0].Value.ToString());
            string lector = dgvSolicitudes.CurrentRow.Cells[1].Value.ToString();
            string libro = dgvSolicitudes.CurrentRow.Cells[2].Value.ToString();
            string cantidad = dgvSolicitudes.CurrentRow.Cells[3].Value.ToString();
            int idLector = int.Parse(dgvSolicitudes.CurrentRow.Cells[4].Value.ToString());
            int idLibro = int.Parse(dgvSolicitudes.CurrentRow.Cells[5].Value.ToString());

            Solicitud.txtCantidad.Text = cantidad;
            Solicitud.txtLibro.Text = libro;
            Solicitud.Id = id;
            Solicitud.Idlector = idLector;
            Solicitud.Idlibro = idLibro;
            Solicitud.txtLector.Text = lector;

        }
        public FrmSolicitudesCrud Solicitud = new FrmSolicitudesCrud();


        

        private void frmSolicitudes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }


        private void dgvSolicitudes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }



  

        private void dgvSolicitudes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.ColumnIndex == dgvSolicitudes.Columns["NUEVA"].Index )
                {
                    Solicitud.btnGuardar.Show();
                    Solicitud.btnGuardar.Enabled = true;
                    Solicitud.btnActualizar.Hide();
                    Solicitud.btnEliminar.Hide();
                    Solicitud.btnSeleccionarLibro.Show();
                    Solicitud.btnSeleccionarLibro.Enabled = true;
                    Solicitud.txtCantidad.Enabled = true;
                    Solicitud.Limpiar();
                    Solicitud.ShowDialog();
                }
                else if (e.ColumnIndex == dgvSolicitudes.Columns["EDITAR"].Index && e.RowIndex != -1)
                {
                    Solicitud.btnGuardar.Hide();
                    Solicitud.btnActualizar.Show();
                    Solicitud.btnActualizar.Enabled = true;
                    Solicitud.btnEliminar.Hide();
                    Seleccionar();
                    Solicitud.ShowDialog();
                }
                else if (e.ColumnIndex == dgvSolicitudes.Columns["ELIMINAR"].Index && e.RowIndex != -1)
                {
                    Solicitud.btnGuardar.Hide();
                    Solicitud.btnActualizar.Hide();
                    Solicitud.btnEliminar.Show();
                    Solicitud.btnEliminar.Enabled = true;
                    Solicitud.btnSeleccionarLibro.Hide();
                    Solicitud.txtCantidad.Enabled = false;
                    Seleccionar();
                    Solicitud.ShowDialog();
                }
                else if (e.ColumnIndex == dgvSolicitudes.Columns["RECIBIR"].Index && e.RowIndex != -1)
                {
                    int idLector = int.Parse(dgvSolicitudes.CurrentRow.Cells[4].Value.ToString());
                    string lector = dgvSolicitudes.CurrentRow.Cells[1].Value.ToString();
                    int idLibro = int.Parse(dgvSolicitudes.CurrentRow.Cells[5].Value.ToString());
                    string libro = dgvSolicitudes.CurrentRow.Cells[2].Value.ToString();
                    string cantidad = dgvSolicitudes.CurrentRow.Cells[3].Value.ToString();
                int cantidadLibros =0;
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    var lista = db.Libros.Where(libros => libros.Id_libro == idLibro)
                        .Select(libros => new { libros.cantidad });


                   

                    foreach (var i in lista)
                    {
                        cantidadLibros = i.cantidad;
                    }
                }


                if (cantidadLibros < Int32.Parse(cantidad)) { 

                    DialogResult resultado = MessageBox.Show("La cantidad de libros solicitada es menor a la exitente, desea alquilar "+cantidadLibros.ToString() +" libros?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if(resultado == DialogResult.Yes)
                    {
                        FrmPrincipal.Prestamos.Alquiler.IdLibro = idLibro;
                        FrmPrincipal.Prestamos.Alquiler.txtLibro.Text = libro;
                        FrmPrincipal.Prestamos.Alquiler.txtLector.Text = lector;
                        FrmPrincipal.Prestamos.Alquiler.IdLector = idLector;
                        FrmPrincipal.Prestamos.Alquiler.txtCantidad.Text = cantidadLibros.ToString();
                        FrmPrincipal.Prestamos.Alquiler.Solicitud = int.Parse(dgvSolicitudes.CurrentRow.Cells[0].Value.ToString());
                        FrmPrincipal.Prestamos.Alquiler.txtCantidad.Enabled = false;
                        FrmPrincipal.Prestamos.Alquiler.btnRecibir.Hide();
                        FrmPrincipal.Prestamos.Alquiler.btnGuardar.Enabled = true;
                        FrmPrincipal.Prestamos.Alquiler.btnGuardar.Show();
                        FrmPrincipal.Prestamos.Alquiler.btnSeleccionarLector.Hide();
                        FrmPrincipal.Prestamos.Alquiler.btnSeleccionarLibro.Hide();
                        FrmPrincipal.Prestamos.Alquiler.ShowDialog();
                    }

                }
                else
                {
                    FrmPrincipal.Prestamos.Alquiler.IdLibro = idLibro;
                    FrmPrincipal.Prestamos.Alquiler.txtLibro.Text = libro;
                    FrmPrincipal.Prestamos.Alquiler.txtLector.Text = lector;
                    FrmPrincipal.Prestamos.Alquiler.IdLector = idLector;
                    FrmPrincipal.Prestamos.Alquiler.txtCantidad.Text = cantidad;
                    FrmPrincipal.Prestamos.Alquiler.Solicitud = int.Parse(dgvSolicitudes.CurrentRow.Cells[0].Value.ToString());
                    FrmPrincipal.Prestamos.Alquiler.txtCantidad.Enabled = false;
                    FrmPrincipal.Prestamos.Alquiler.btnRecibir.Hide();
                    FrmPrincipal.Prestamos.Alquiler.btnGuardar.Enabled = true;
                    FrmPrincipal.Prestamos.Alquiler.btnGuardar.Show();
                    FrmPrincipal.Prestamos.Alquiler.btnSeleccionarLector.Hide();
                    FrmPrincipal.Prestamos.Alquiler.btnSeleccionarLibro.Hide();
                    FrmPrincipal.Prestamos.Alquiler.ShowDialog();
                }
                }
            

        }

       
        private void lblMessage_Click(object sender, EventArgs e)
        {

        }
    }
    } 
