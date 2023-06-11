using AdminLabrary.Model;
using AdminLabrary.View.principales;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class FrmAutoresCrud : Form
    {
        private Autores _autor = new Autores();

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
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtNacionalidad.Text))
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    Autores autor = new Autores
                    {
                        Nombre = txtNombre.Text,
                        Nacionalidad = txtNacionalidad.Text,
                        fecha_nacimiento = Convert.ToDateTime(dtpFecha.Text),
                        estado = 0
                    };

                    db.Autores.Add(autor);
                    db.SaveChanges();
                    FrmPrincipal.Autor.CargarDatos();
                    Limpiar();
                    Close();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtNacionalidad.Text))
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    Autores autor = db.Autores.FirstOrDefault(buscarId => buscarId.Id_autor == Id);

                    if (autor != null)
                    {
                        autor.Nombre = txtNombre.Text;
                        autor.Nacionalidad = txtNacionalidad.Text;
                        autor.fecha_nacimiento = Convert.ToDateTime(dtpFecha.Text);
                        autor.estado = 0;

                        db.Entry(autor).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        Limpiar();
                        FrmPrincipal.Autor.CargarDatos();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el autor en la base de datos");
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                Autores autor = db.Autores.FirstOrDefault(buscarId => buscarId.Id_autor == Id);

                if (autor != null)
                {
                    autor.Nombre = txtNombre.Text;
                    autor.Nacionalidad = txtNacionalidad.Text;
                    autor.fecha_nacimiento = Convert.ToDateTime(dtpFecha.Text);
                    autor.estado = 1;

                    db.Entry(autor).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Autor.CargarDatos();
                    Close();
                }
                else
                {
                    MessageBox.Show("No se encontró el autor en la base de datos");
                }
            }
        }

        private void frmAutoresCRUD_Load(object sender, EventArgs e)
        {

        }
    }
}
