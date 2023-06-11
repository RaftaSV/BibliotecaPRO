using AdminLabrary.Model;
using AdminLabrary.View.buscar;
using AdminLabrary.View.principales;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class FrmSolicitudesCrud : Form
    {
        public FrmSolicitudesCrud()
        {
            InitializeComponent();
            Limpiar();


        }

        public void Limpiar()
        {
            txtLibro.Text = "";
            txtCantidad.Text = "";
            txtLector.Text = "";


        }
        public int Idlector;

        public int Idlibro;
        public int Id;
        solicitudes _soli = new solicitudes();

        

        private void btnSeleccionarLector_Click(object sender, EventArgs e)
        {
            FrmBuscarLibros buscarL = new FrmBuscarLibros();

            buscarL.Indicador = 1;
            buscarL.ShowDialog();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLibro.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad ingresada no es un número válido o es menor o igual a cero.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                _soli.Cantidad = cantidad;
                _soli.libros = Idlibro;
                _soli.id_lector = Idlector;
                _soli.estado = 0;
                db.solicitudes.Add(_soli);
                db.SaveChanges();
                Limpiar();
                FrmPrincipal.Sol.CargarDatos();
                Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLibro.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad ingresada no es un número válido o es menor o igual a cero.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                _soli = db.solicitudes.FirstOrDefault(buscarId => buscarId.id_soli == Id);
                if (_soli != null)
                {
                    _soli.Cantidad = cantidad;
                    _soli.libros = Idlibro;
                    _soli.id_lector = Idlector;
                    _soli.estado = 0;
                    db.Entry(_soli).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Sol.CargarDatos();
                    Close();
                }
                else
                {
                    MessageBox.Show("No se encontró la solicitud a actualizar");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLibro.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad ingresada no es un número válido o es menor o igual a cero.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                _soli = db.solicitudes.FirstOrDefault(buscarId => buscarId.id_soli == Id);
                if (_soli != null)
                {
                    _soli.Cantidad = cantidad;
                    _soli.libros = Idlibro;
                    _soli.id_lector = Idlector;
                    _soli.estado = 1;
                    db.Entry(_soli).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Sol.CargarDatos();
                    Close();
                }
                else
                {
                    MessageBox.Show("No se encontró la solicitud a eliminar");
                }
            }
        }


        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            string cadena = txtCantidad.Text;
            try
            {

                if (int.Parse(txtCantidad.Text) < 0)
                {
                    txtCantidad.Text = "";
                }
            }
            catch
            {
                int c = cadena.Length;
                if (c == 0)
                {
                    txtCantidad.Text = "";
                }
                else
                {
                    txtCantidad.Text = cadena.Remove(c - 1);
                    txtCantidad.SelectionStart = c - 1;
                }

            }
        }

        private void btnSeleccionarLector_Click_1(object sender, EventArgs e)
        {
            FrmBuscarLector lec = new FrmBuscarLector();
            lec.Indicador = 3;
            lec.Filtro();
            lec.ShowDialog();
        }

        private void FrmSolicitudesCrud_Load(object sender, EventArgs e)
        {

        }
    }
}
