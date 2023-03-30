using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.Model;
using AdminLabrary.formularios.principales;
using AdminLabrary.View.buscar;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class frmSolicitudesCRUD : Form
    {
        public frmSolicitudesCRUD()
        {
            InitializeComponent();
            limpiar();
            
           
        }
       
        public void limpiar()
        {
            txtLibro.Text = "";
            txtCantidad.Text = "";
            txtLector.Text = "";
            

        }
        public int idlector;
      
        public int idlibro;
        public int ID;
        solicitudes soli = new solicitudes();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using(BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                if (txtCantidad.Text != "" && txtLibro.Text != "")    
                {

                   if (int.Parse(txtCantidad.Text) > 0 )
                   {

                        soli.Cantidad = int.Parse(txtCantidad.Text);
                        soli.libros = idlibro;
                        soli.id_lector = idlector;
                        soli.estado = 0;
                        db.solicitudes.Add(soli);
                        db.SaveChanges();
                        limpiar();
                        frmPrincipal.Sol.CargarDatos();

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
            frmBuscarLibros BuscarL = new frmBuscarLibros();

            BuscarL.indicador = 1;
            BuscarL.ShowDialog();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtLibro.Text != "" && txtCantidad.Text != ""  && int.Parse(txtCantidad.Text) > 0 )
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    soli = db.solicitudes.First(buscarID => buscarID.id_soli == ID);
                    soli.Cantidad = int.Parse(txtCantidad.Text);
                    soli.libros = idlibro;
                    soli.id_lector = idlector;
                    soli.estado = 0;
                    db.Entry(soli).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    limpiar();
                    frmPrincipal.Sol.CargarDatos();
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
                    soli = db.solicitudes.First(buscarID => buscarID.id_soli == ID);
                    soli.Cantidad = int.Parse(txtCantidad.Text);
                    soli.libros = idlibro;
                    soli.id_lector = idlector;
                    soli.estado = 1;
                    db.Entry(soli).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    limpiar();
                    frmPrincipal.Sol.CargarDatos();
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
            frmBuscarLector lec = new frmBuscarLector();
            lec.indicador = 3;
            lec.filtro();
            lec.ShowDialog();
        }
    }
}
