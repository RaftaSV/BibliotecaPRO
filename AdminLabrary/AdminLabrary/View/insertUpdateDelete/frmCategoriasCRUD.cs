using AdminLabrary.Model;
using AdminLabrary.View.principales;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class FrmCategoriasCrud : Form
    {

        public FrmCategoriasCrud()
        {
            InitializeComponent();
        }
        public int Id;

        public void Limpiar()
        {
            txtCategoria.Text = "";
            txtCategoria.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    Categorias categoria = new Categorias
                    {
                        Categoria = txtCategoria.Text,
                        estado = 0
                    };
                    db.Categorias.Add(categoria);
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Categoria.CargarDatos();
                    Close();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    Categorias categoria = db.Categorias.FirstOrDefault(buscarId => buscarId.Id_categoria == Id);
                    if (categoria != null)
                    {
                        categoria.Categoria = txtCategoria.Text;
                        categoria.estado = 0;
                        db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        Limpiar();
                        FrmPrincipal.Categoria.CargarDatos();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la categoría en la base de datos");
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                Categorias categoria = db.Categorias.FirstOrDefault(buscarId => buscarId.Id_categoria == Id);
                if (categoria != null)
                {
                    categoria.Categoria = txtCategoria.Text;
                    categoria.estado = 1;
                    db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Categoria.CargarDatos();
                    Close();
                }
                else
                {
                    MessageBox.Show("No se encontró la categoría en la base de datos");
                }
            }
        }

        private void frmCategoriasCRUD_Load(object sender, EventArgs e)
        {

        }
    }
}
