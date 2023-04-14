using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.Model;
using AdminLabrary.View.buscar;
using AdminLabrary.View.principales;

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using(BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                if (txtCantidad.Text != "" && txtLibro.Text != "")    
                {

                   if (int.Parse(txtCantidad.Text) > 0 )
                   {

                        _soli.Cantidad = int.Parse(txtCantidad.Text);
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
                else
                {
                    MessageBox.Show("Todos los campos son obligatorios");
                }


            }
        }

        private void btnSeleccionarLector_Click(object sender, EventArgs e)
        {
            FrmBuscarLibros buscarL = new FrmBuscarLibros();

            buscarL.Indicador = 1;
            buscarL.ShowDialog();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtLibro.Text != "" && txtCantidad.Text != ""  && int.Parse(txtCantidad.Text) > 0 )
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    _soli = db.solicitudes.First(buscarId => buscarId.id_soli == Id);
                    _soli.Cantidad = int.Parse(txtCantidad.Text);
                    _soli.libros = Idlibro;
                    _soli.id_lector = Idlector;
                    _soli.estado = 0;
                    db.Entry(_soli).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Sol.CargarDatos();
                    Close();
                }

            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtLibro.Text != "" && txtCantidad.Text != ""  && int.Parse(txtCantidad.Text) > 0)
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    _soli = db.solicitudes.First(buscarId => buscarId.id_soli == Id);
                    _soli.Cantidad = int.Parse(txtCantidad.Text);
                    _soli.libros = Idlibro;
                    _soli.id_lector = Idlector;
                    _soli.estado = 1;
                    db.Entry(_soli).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Sol.CargarDatos();
                    Close();
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
                if(c == 0)
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
    }
}
