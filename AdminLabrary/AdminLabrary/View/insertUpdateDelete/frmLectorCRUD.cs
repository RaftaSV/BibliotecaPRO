using AdminLabrary.Model;
using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.View.principales;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class FrmLectorCrud : Form
    {
        public string Id;
        public FrmLectorCrud()
        {
           
            InitializeComponent();
          
        }

        public void Limpiar()
        {
            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtApellidos.Enabled = true;
            txtNombre.Enabled = true;
        }

        Lectores _lector = new Lectores();
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtApellidos.Text !="" && txtNombre.Text != "") {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    _lector.Nombres = txtNombre.Text;
                    _lector.Apellidos = txtApellidos.Text;
                    _lector.estado = 0;
                    db.Lectores.Add(_lector);
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Lector.CargarDatos();
                    Close();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtApellidos.Text != "" && txtNombre.Text != "")
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    int id = int.Parse(Id);
                    _lector = db.Lectores.First(buscarid => buscarid.Id_Lector == id);
                    _lector.Nombres = txtNombre.Text;
                    _lector.Apellidos = txtApellidos.Text;
                    _lector.estado = 0;
                    db.Entry(_lector).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Lector.CargarDatos();
                    Close();
                }


            }
        }

        private void frmNuevoLector_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                int id = int.Parse(Id);
                _lector = db.Lectores.First(buscarid => buscarid.Id_Lector == id);
                _lector.Nombres = txtNombre.Text;
                _lector.Apellidos = txtApellidos.Text;
                _lector.estado = 1;
                db.Entry(_lector).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Limpiar();
                FrmPrincipal.Lector.CargarDatos();
                Console.WriteLine("eliminar" + id);
                Close();
               
            }
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblApellidos_Click(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
