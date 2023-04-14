using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.View.buscar;
using AdminLabrary.Model;
using AdminLabrary.View.principales;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class FrmLibrosCrud : Form
    {
        public FrmLibrosCrud()
        {
            InitializeComponent();
            CargarCombo();
        }

        public int IdLibro;
        public string IdCate="";
        public int Id =0;
        public int IdEditorial;
        public int IdAutor;
        public int Indi = 0;
        

       public void Limpiar()
        {
            txtAutor.Text = "";
            txtCantidad.Text = "";
            txtEditorial.Text = "";
            txtNombre.Text = "";
            txtNumero_de_Edicion.Text = "";
            IdAutor = 0;
            IdCate = "0";
            IdEditorial = 0;
            dtpAño.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void btnSeleccionarA_Click(object sender, EventArgs e)
        {
            FrmBuscarAutor buscarA = new FrmBuscarAutor();
            buscarA.ShowDialog();

        }
        Libros _lib = new Libros();

        void CargarCombo()
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {

                var lista = from ca in db.Categorias
                            where ca.estado == 0
                            select ca;
                cmbCategoria.DataSource = lista.ToList();
                cmbCategoria.DisplayMember = "Categoria";
                cmbCategoria.ValueMember = "Id_categoria";
                cmbCategoria.SelectedIndex = Id;
               
               
            }

            
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtAutor.Text != "" && txtCantidad.Text != "" 
                && txtEditorial.Text != "" && txtNumero_de_Edicion.Text != "" && int.Parse(txtCantidad.Text) > 0)
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    _lib.Nombre = txtNombre.Text;
                    _lib.cantidad = int.Parse(txtCantidad.Text);
                    _lib.Año = Convert.ToDateTime(dtpAño.Text);
                    _lib.Id_categoria = int.Parse(IdCate);
                    _lib.Id_autor = IdAutor;
                    _lib.Id_Editorial = IdEditorial;
                    _lib.Numero_edicion = int.Parse(txtNumero_de_Edicion.Text);
                    _lib.estado = 0;
                    db.Libros.Add(_lib);
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Lib.CargaDatos();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios");
            }


        }

        private void frmLibrosCRUD_Load(object sender, EventArgs e)
        {
            CargarCombo();
          
            if (Indi !=0)
            {
                txtAutor.Enabled = false;
                txtCantidad.Enabled = false;
                txtEditorial.Enabled = false;
                txtNombre.Enabled = false;
                txtNumero_de_Edicion.Enabled = false;
                btnActualizar.Enabled = false;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = true;
                dtpAño.Enabled = false;
                btnSeleccionarA.Enabled = false;
                btnSeleccionarE.Enabled = false;
                cmbCategoria.Enabled = false;

            }
            else
            {
              
                txtCantidad.Enabled = true;
               
                txtNombre.Enabled = true;
                txtNumero_de_Edicion.Enabled = true;
                btnSeleccionarA.Enabled = true;
                btnSeleccionarE.Enabled = true;
                cmbCategoria.Enabled = true;
            }

        }

        private void btnSeleccionarE_Click(object sender, EventArgs e)
        {
            FrmBuscarEditoriales edi = new FrmBuscarEditoriales();
            edi.ShowDialog();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

           IdCate = cmbCategoria.SelectedValue.ToString();


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtAutor.Text != "" && txtCantidad.Text != ""
               && txtEditorial.Text != "" && txtNumero_de_Edicion.Text != "" && int.Parse(txtCantidad.Text) > 0)
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    _lib = db.Libros.First(buscarid => buscarid.Id_libro== IdLibro);
                    _lib.Nombre = txtNombre.Text;
                    _lib.cantidad = int.Parse(txtCantidad.Text);
                    _lib.Año = Convert.ToDateTime(dtpAño.Text);
                    _lib.Id_categoria = int.Parse(IdCate);
                    _lib.Id_autor = IdAutor;
                    _lib.Id_Editorial = IdEditorial;
                    _lib.Numero_edicion = int.Parse(txtNumero_de_Edicion.Text);
                    _lib.estado = 0;
                    db.Entry(_lib).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Lib.CargaDatos();
                    Close();
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text != "" && txtAutor.Text != "" && txtCantidad.Text != ""
               && txtEditorial.Text != "" && txtNumero_de_Edicion.Text != "")
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    _lib = db.Libros.First(buscarid => buscarid.Id_libro == IdLibro);
                    _lib.Nombre = txtNombre.Text;
                    _lib.cantidad = int.Parse(txtCantidad.Text);
                    _lib.Año = Convert.ToDateTime(dtpAño.Text);
                    _lib.Id_categoria = int.Parse(IdCate);
                    _lib.Id_autor = IdAutor;
                    _lib.Id_Editorial = IdEditorial;
                    _lib.Numero_edicion = int.Parse(txtNumero_de_Edicion.Text);
                    _lib.estado = 1;
                    db.Entry(_lib).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Limpiar();
                    FrmPrincipal.Lib.CargaDatos();
                    Close();
                }
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            string cadena = txtCantidad.Text;
            try
            {

                if (int.Parse(txtCantidad.Text) < 0)
                {
                    txtCantidad.Text = "";
                }
            }
            catch
            {
                int c = cadena.Length;
                if (c == 0)
                {
                    txtCantidad.Text = "";
                }
                else
                {
                    txtCantidad.Text = cadena.Remove(c - 1);
                    txtCantidad.SelectionStart = c - 1;
                }

            }
        }

        private void txtNumero_de_Edicion_TextChanged(object sender, EventArgs e)
        {
            string cadena = txtNumero_de_Edicion.Text;
            try
            {

                if (int.Parse(txtNumero_de_Edicion.Text) < 0)
                {
                    txtNumero_de_Edicion.Text = "";
                }
            }
            catch
            {
                int c = cadena.Length;
                if (c == 0)
                {
                    txtNumero_de_Edicion.Text = "";
                }
                else
                {
                    txtNumero_de_Edicion.Text = cadena.Remove(c - 1);
                    txtNumero_de_Edicion.SelectionStart = c - 1;
                }

            }
        }
    }
    
    
}
