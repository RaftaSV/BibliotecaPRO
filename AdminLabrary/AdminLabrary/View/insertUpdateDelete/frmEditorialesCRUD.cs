using AdminLabrary.formularios.principales;
using AdminLabrary.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class frmEditorialesCRUD : Form
    {
        public frmEditorialesCRUD()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            txtEditorial.Text = "";
            txtDirecion.Text = "";
            dtpFecha.Value = DateTime.Now;
            txtEditorial.Enabled = true;
        }
        Editoriales Edit = new Editoriales();
        public int ID;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtEditorial.Text != "" && txtDirecion.Text!="")
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    Edit.Editorial = txtEditorial.Text;
                    Edit.Fundada = Convert.ToDateTime(dtpFecha.Text);
                    Edit.Direccion = txtDirecion.Text;
                    Edit.estado = 0;
                    db.Editoriales.Add(Edit);
                    db.SaveChanges();
                    limpiar();
                    frmPrincipal.Editorial.CargarDatos();
                    Close();
                }

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtEditorial.Text != "" && txtDirecion.Text != "")
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    Edit = db.Editoriales.First(buscarId => buscarId.Id_Editorial == ID);
                    Edit.Editorial = txtEditorial.Text;
                    Edit.Fundada = Convert.ToDateTime(dtpFecha.Text);
                    Edit.Direccion = txtDirecion.Text;
                    Edit.estado = 0;
                    db.Entry(Edit).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    limpiar();
                    frmPrincipal.Editorial.CargarDatos();
                    Close();


                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                Edit = db.Editoriales.First(buscarId => buscarId.Id_Editorial == ID);
                Edit.Editorial = txtEditorial.Text;
                Edit.Fundada = Convert.ToDateTime(dtpFecha.Text);
                Edit.Direccion = txtDirecion.Text;
                Edit.estado = 1;
                db.Entry(Edit).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                limpiar();
                frmPrincipal.Editorial.CargarDatos();
                Close();
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
