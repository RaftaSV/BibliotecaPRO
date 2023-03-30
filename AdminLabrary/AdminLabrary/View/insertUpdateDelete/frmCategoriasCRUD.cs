using AdminLabrary.formularios.principales;
using AdminLabrary.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class frmCategoriasCRUD : Form
    {
        public frmCategoriasCRUD()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            txtCategoria.Text = "";
            txtCategoria.Enabled = true;
        }
        Categorias categoria = new Categorias();
        public int ID;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text!= "")
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    categoria.Categoria = txtCategoria.Text;
                    categoria.estado = 0;
                    db.Categorias.Add(categoria);
                    db.SaveChanges();
                    limpiar();
                    frmPrincipal.categoria.CargarDatos();
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
                    categoria = db.Categorias.First(buscarId => buscarId.Id_categoria == ID);
                    categoria.Categoria = txtCategoria.Text;
                    categoria.estado = 0;
                    db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    limpiar();
                    frmPrincipal.categoria.CargarDatos();
                    Close();


                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                categoria = db.Categorias.First(buscarId => buscarId.Id_categoria == ID);
                categoria.Categoria = txtCategoria.Text;
                categoria.estado = 1;
                db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                limpiar();
                frmPrincipal.categoria.CargarDatos();
                Close();
            }
        }


        private void frmCategoriasCRUD_Load(object sender, EventArgs e)
        {

        }
    }
}
