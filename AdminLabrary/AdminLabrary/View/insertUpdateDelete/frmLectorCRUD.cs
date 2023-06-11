using AdminLabrary.Model;
using AdminLabrary.View.principales;
using System;
using System.Linq;
using System.Windows.Forms;

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtApellidos.Text) && !string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    Lectores lector = new Lectores
                    {
                        Nombres = txtNombre.Text,
                        Apellidos = txtApellidos.Text,
                        estado = 0
                    };
                    db.Lectores.Add(lector);
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Lector.CargarDatos();
                    Close();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtApellidos.Text) && !string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    int id = int.Parse(Id);
                    Lectores lector = db.Lectores.FirstOrDefault(buscarid => buscarid.Id_Lector == id);
                    if (lector != null)
                    {
                        lector.Nombres = txtNombre.Text;
                        lector.Apellidos = txtApellidos.Text;
                        lector.estado = 0;
                        db.Entry(lector).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        Limpiar();
                        FrmPrincipal.Lector.CargarDatos();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el lector en la base de datos");
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                int id = int.Parse(Id);
                Lectores lector = db.Lectores.FirstOrDefault(buscarid => buscarid.Id_Lector == id);
                if (lector != null)
                {
                    lector.Nombres = txtNombre.Text;
                    lector.Apellidos = txtApellidos.Text;
                    lector.estado = 1;
                    db.Entry(lector).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Lector.CargarDatos();
                    Console.WriteLine("eliminar" + id);
                    Close();
                }
                else
                {
                    MessageBox.Show("No se encontró el lector en la base de datos");
                }
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
