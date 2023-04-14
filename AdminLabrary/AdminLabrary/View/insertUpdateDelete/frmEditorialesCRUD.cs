using AdminLabrary.Model;
using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.View.principales;

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
        Editoriales _edit = new Editoriales();
        public int Id;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtEditorial.Text != "" && txtDirecion.Text!="")
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    _edit.Editorial = txtEditorial.Text;
                    _edit.Fundada = Convert.ToDateTime(dtpFecha.Text);
                    _edit.Direccion = txtDirecion.Text;
                    _edit.estado = 0;
                    db.Editoriales.Add(_edit);
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Editorial.CargarDatos();
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
                    _edit = db.Editoriales.First(buscarId => buscarId.Id_Editorial == Id);
                    _edit.Editorial = txtEditorial.Text;
                    _edit.Fundada = Convert.ToDateTime(dtpFecha.Text);
                    _edit.Direccion = txtDirecion.Text;
                    _edit.estado = 0;
                    db.Entry(_edit).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Editorial.CargarDatos();
                    Close();


                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                _edit = db.Editoriales.First(buscarId => buscarId.Id_Editorial == Id);
                _edit.Editorial = txtEditorial.Text;
                _edit.Fundada = Convert.ToDateTime(dtpFecha.Text);
                _edit.Direccion = txtDirecion.Text;
                _edit.estado = 1;
                db.Entry(_edit).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Limpiar();
                FrmPrincipal.Editorial.CargarDatos();
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
