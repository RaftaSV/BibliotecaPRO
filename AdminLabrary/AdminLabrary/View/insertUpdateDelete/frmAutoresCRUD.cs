using AdminLabrary.Model;
using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.View.principales;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class FrmAutoresCrud : Form
    {
        Autores _autor = new Autores();
        public FrmAutoresCrud()
        {
            InitializeComponent();
        }
        public int Id;

        public void Limpiar()
        {
            txtNacionalidad.Text = "";
            txtNombre.Text = "";
            dtpFecha.Value = DateTime.Now;
            txtNacionalidad.Enabled = true;
            txtNombre.Enabled = true;
            dtpFecha.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtNacionalidad.Text!= "")
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    _autor.Nombre = txtNombre.Text;
                    _autor.Nacionalidad = txtNacionalidad.Text;
                    _autor.fecha_nacimiento = Convert.ToDateTime(dtpFecha.Text);
                    _autor.estado = 0;
                    db.Autores.Add(_autor);
                    db.SaveChanges();
                    FrmPrincipal.Autor.CargarDatos();
                    Limpiar();
                    Close();
                }

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtNacionalidad.Text != "")
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    _autor = db.Autores.First(buscarId => buscarId.Id_autor == Id);
                    _autor.Nombre = txtNombre.Text;
                    _autor.Nacionalidad = txtNacionalidad.Text;
                    _autor.fecha_nacimiento = Convert.ToDateTime(dtpFecha.Text);
                    _autor.estado = 0;
                    db.Entry(_autor).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Autor.CargarDatos();
                    Close();
                }

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                _autor = db.Autores.First(buscarId => buscarId.Id_autor == Id);
                _autor.Nombre = txtNombre.Text;
                _autor.Nacionalidad = txtNacionalidad.Text;
                _autor.fecha_nacimiento = Convert.ToDateTime(dtpFecha.Text);
                _autor.estado = 1;
                db.Entry(_autor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Limpiar();
                FrmPrincipal.Autor.CargarDatos();
                Close();
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAutoresCRUD_Load(object sender, EventArgs e)
        {

        }
    }
}
