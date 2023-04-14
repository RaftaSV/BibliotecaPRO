using AdminLabrary.Model;
using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.View.principales;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class FrmCategoriasCrud : Form
    {
        public FrmCategoriasCrud()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            txtCategoria.Text = "";
            txtCategoria.Enabled = true;
        }
        Categorias _categoria = new Categorias();
        public int Id;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text!= "")
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    _categoria.Categoria = txtCategoria.Text;
                    _categoria.estado = 0;
                    db.Categorias.Add(_categoria);
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Categoria.CargarDatos();
                    Close();
                }

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text != "")
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    _categoria = db.Categorias.First(buscarId => buscarId.Id_categoria == Id);
                    _categoria.Categoria = txtCategoria.Text;
                    _categoria.estado = 0;
                    db.Entry(_categoria).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Categoria.CargarDatos();
                    Close();


                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                _categoria = db.Categorias.First(buscarId => buscarId.Id_categoria == Id);
                _categoria.Categoria = txtCategoria.Text;
                _categoria.estado = 1;
                db.Entry(_categoria).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Limpiar();
                FrmPrincipal.Categoria.CargarDatos();
                Close();
            }
        }


        private void frmCategoriasCRUD_Load(object sender, EventArgs e)
        {

        }
    }
}
