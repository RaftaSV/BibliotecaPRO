using AdminLabrary.Model;
using AdminLabrary.View.principales;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class FrmEditorialesCrud : Form
    {
        public FrmEditorialesCrud()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            txtEditorial.Text = "";
            txtDirecion.Text = "";
            dtpFecha.Value = DateTime.Now;
            txtEditorial.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEditorial.Text) && !string.IsNullOrWhiteSpace(txtDirecion.Text))
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    Editoriales editorial = new Editoriales
                    {
                        Editorial = txtEditorial.Text,
                        Fundada = Convert.ToDateTime(dtpFecha.Text),
                        Direccion = txtDirecion.Text,
                        estado = 0
                    };
                    db.Editoriales.Add(editorial);
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Editorial.CargarDatos();
                    Close();
                }
            }
        }
        public int Id;
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEditorial.Text) && !string.IsNullOrWhiteSpace(txtDirecion.Text))
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    Editoriales editorial = db.Editoriales.FirstOrDefault(buscarId => buscarId.Id_Editorial == Id);
                    if (editorial != null)
                    {
                        editorial.Editorial = txtEditorial.Text;
                        editorial.Fundada = Convert.ToDateTime(dtpFecha.Text);
                        editorial.Direccion = txtDirecion.Text;
                        editorial.estado = 0;
                        db.Entry(editorial).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        Limpiar();
                        FrmPrincipal.Editorial.CargarDatos();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la editorial en la base de datos");
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                Editoriales editorial = db.Editoriales.FirstOrDefault(buscarId => buscarId.Id_Editorial == Id);
                if (editorial != null)
                {
                    editorial.Editorial = txtEditorial.Text;
                    editorial.Fundada = Convert.ToDateTime(dtpFecha.Text);
                    editorial.Direccion = txtDirecion.Text;
                    editorial.estado = 1;
                    db.Entry(editorial).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Editorial.CargarDatos();
                    Close();
                }
                else
                {
                    MessageBox.Show("No se encontró la editorial en la base de datos");
                }
            }
        }

        private void frmEditoriales_Load(object sender, EventArgs e)
        {

        }

        private void txtDirecion_TextChanged(object sender, EventArgs e)
        {
            txtDirecion.SelectionStart = txtDirecion.Text.Length;
        }
    }
}
