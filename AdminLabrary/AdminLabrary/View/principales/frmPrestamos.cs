using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.Model;
using AdminLabrary.View.buscar;
using AdminLabrary.View.insertUpdateDelete;

namespace AdminLabrary.View.principales
{
    public partial class FrmPrestamos : Form
    {
        public FrmPrestamos()
        {
            InitializeComponent();
        }

        private void frmPrestamos_Load(object sender, EventArgs e)
        {
            rbtnLector.Checked = true;
            CargarDatos();
        }

        public void CargarDatos()
        {
            dgvPrestamos.Rows.Clear();
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
               
                if (rbtnLector.Checked)
                {
                    string buscar = txtBuscar.Text;
                    var lista = from pre in db.Alquileres
                                from li in db.Libros
                                from le in db.Lectores
                                from ad in db.Roles
                                where pre.Id_Lector == le.Id_Lector
                                && pre.Id_libro == li.Id_libro
                                && pre.Entregado == ad.Id_rol
                                && pre.Recibido == null
                                && le.Nombres.Contains(buscar)


                                select new
                                {
                                    ID = pre.Id_alquiler,
                                    Lector = le.Nombres,
                                    Libro = li.Nombre,
                                    Cantidad = pre.cantidad,
                                    Entregado = ad.Usuario,
                                    Fecha_salida = pre.fecha_salida,
                                    Fecha_prevista_Entrega = pre.fecha_prevista_de_entrega,
                                    IDLector = pre.Id_Lector,
                                    IDLibro = pre.Id_libro,
                                    IDEntregado = pre.Entregado
                                };

                    foreach (var i in lista)
                    {
                        dgvPrestamos.Rows.Add(i.ID, i.Lector, i.Libro, i.Cantidad, i.Entregado, i.Fecha_salida, i.Fecha_prevista_Entrega, i.IDLector, i.IDLibro, i.IDEntregado) ;
                    }
                }
                else if (rbtnLibro.Checked)
                {
                    {
                        string buscar = txtBuscar.Text;
                        var lista = from pre in db.Alquileres
                                    from li in db.Libros
                                    from le in db.Lectores
                                    from ad in db.Roles
                                    where pre.Id_Lector == le.Id_Lector
                                    && pre.Id_libro == li.Id_libro
                                    && pre.Entregado == ad.Id_rol
                                    && pre.Recibido == null
                                    && li.Nombre.Contains(buscar)


                                    select new
                                    {
                                        ID = pre.Id_alquiler,
                                        Lector = le.Nombres,
                                        Libro = li.Nombre,
                                        Cantidad = pre.cantidad,
                                        Entregado = ad.Usuario,
                                        Fecha_salida = pre.fecha_salida,
                                        Fecha_prevista_Entrega = pre.fecha_prevista_de_entrega,
                                        IDLector = pre.Id_Lector,
                                        IDLibro = pre.Id_libro,
                                        IDEntregado = pre.Entregado
                                    };

                        foreach (var i in lista)
                        {
                            dgvPrestamos.Rows.Add(i.ID, i.Lector, i.Libro, i.Cantidad, i.Entregado, i.Fecha_salida, i.Fecha_prevista_Entrega, i.IDLector, i.IDLibro, i.IDEntregado);

                        }
                    }
                }
                else if (rbtnAdministrador.Checked)
                {
                    {
                        string buscar = txtBuscar.Text;
                        var lista = from pre in db.Alquileres
                                    from li in db.Libros
                                    from le in db.Lectores
                                    from ad in db.Roles
                                    where pre.Id_Lector == le.Id_Lector
                                    && pre.Id_libro == li.Id_libro
                                    && pre.Entregado == ad.Id_rol
                                    && pre.Recibido == null
                                    && ad.Usuario.Contains(buscar)


                                    select new
                                    {
                                        ID = pre.Id_alquiler,
                                        Lector = le.Nombres,
                                        Libro = li.Nombre,
                                        Cantidad = pre.cantidad,
                                        Entregado = ad.Usuario,
                                        Fecha_salida = pre.fecha_salida,
                                        Fecha_prevista_Entrega = pre.fecha_prevista_de_entrega,
                                        IDLector = pre.Id_Lector,
                                        IDLibro = pre.Id_libro,
                                        IDEntregado = pre.Entregado
                                    };

                        foreach (var i in lista)
                        {
                            dgvPrestamos.Rows.Add(i.ID, i.Lector, i.Libro, i.Cantidad, i.Entregado, i.Fecha_salida, i.Fecha_prevista_Entrega, i.IDLector, i.IDLibro, i.IDEntregado);

                        }
                        
                    }

                }
            }

        }
        public void Ultimafila()
        {
            dgvPrestamos.ClearSelection();
            if (dgvPrestamos.Rows.Count > 0)
            {
                int ultimafila = dgvPrestamos.Rows.Count - 1;
                dgvPrestamos.FirstDisplayedScrollingRowIndex = ultimafila;
                dgvPrestamos.Rows[ultimafila].Selected = true;
            }
        }
        public FrmAlquileresCrud Alquiler = new FrmAlquileresCrud();
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Alquiler.Limpiar();
            Alquiler.txtCantidad.Enabled = true;
           
            Alquiler.Indicador = 1;
            Alquiler.btnGuardar.Show();
            Alquiler.btnRecibir.Hide();
            Alquiler.btnSeleccionarLector.Show();
            Alquiler.btnSeleccionarLibro.Show();
            Alquiler.ShowDialog();

        }

        

        private void btnVer_Click(object sender, EventArgs e)
        {
        
            FrmLogin.F.MostrarPanel(new FrmBuscarAlquiler());
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnRetrazo_Click(object sender, EventArgs e)
        {
            
            FrmLogin.F.MostrarPanel(new FrmHistorial());
        }

        

        private void dgvPrestamos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPrestamos.Columns["Recibir"].Index)
            {

                try
                {
                    if (dgvPrestamos.RowCount > 0)
                    {
                        Alquiler.txtCantidad.Enabled = true;
                        Alquiler.txtLector.Text = dgvPrestamos.CurrentRow.Cells[1].Value.ToString();
                        Alquiler.IdLector = int.Parse(dgvPrestamos.CurrentRow.Cells[7].Value.ToString());
                        Alquiler.txtLibro.Text = dgvPrestamos.CurrentRow.Cells[2].Value.ToString();
                        Alquiler.txtCantidad.Text = dgvPrestamos.CurrentRow.Cells[3].Value.ToString();
                        Alquiler.Cantidad = int.Parse(dgvPrestamos.CurrentRow.Cells[3].Value.ToString());
                        Alquiler.IdLibro = int.Parse(dgvPrestamos.CurrentRow.Cells[8].Value.ToString());
                        Alquiler.IdEntregado = int.Parse(dgvPrestamos.CurrentRow.Cells[9].Value.ToString());
                        Alquiler.FechaSalida = Convert.ToDateTime(dgvPrestamos.CurrentRow.Cells[5].Value.ToString());
                        Alquiler.FechaPre = Convert.ToDateTime(dgvPrestamos.CurrentRow.Cells[5].Value.ToString());
                        Alquiler.IdAlquiler = int.Parse(dgvPrestamos.CurrentRow.Cells[0].Value.ToString());
                        Alquiler.Indicador = 2;
                        Alquiler.btnGuardar.Hide();
                        Alquiler.btnRecibir.Show();
                        Alquiler.btnSeleccionarLector.Hide();
                        Alquiler.btnSeleccionarLibro.Hide();
                        Alquiler.ShowDialog();
                    }
                }
                catch
                {
                    // ignored
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

