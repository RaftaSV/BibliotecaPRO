using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.View.buscar;
using AdminLabrary.Model;
using AdminLabrary.formularios.principales;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class frmLibrosCRUD : Form
    {
        public frmLibrosCRUD()
        {
            InitializeComponent();
            CargarCombo();
        }

        public int ID_Libro;
        public string ID_Cate="";
        public int id =0;
        public int ID_Editorial;
        public int ID_Autor;
        public int indi = 0;
        

       public void limpiar()
        {
            txtAutor.Text = "";
            txtCantidad.Text = "";
            txtEditorial.Text = "";
            txtNombre.Text = "";
            txtNumero_de_Edicion.Text = "";
            ID_Autor = 0;
            ID_Cate = "0";
            ID_Editorial = 0;
            dtpAño.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void btnSeleccionarA_Click(object sender, EventArgs e)
        {
            frmBuscarAutor BuscarA = new frmBuscarAutor();
            BuscarA.ShowDialog();

        }
        Libros Lib = new Libros();

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
                cmbCategoria.SelectedIndex = id;
               
               
            }

            
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtAutor.Text != "" && txtCantidad.Text != "" 
                && txtEditorial.Text != "" && txtNumero_de_Edicion.Text != "" && int.Parse(txtCantidad.Text) > 0)
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    Lib.Nombre = txtNombre.Text;
                    Lib.cantidad = int.Parse(txtCantidad.Text);
                    Lib.Año = Convert.ToDateTime(dtpAño.Text);
                    Lib.Id_categoria = int.Parse(ID_Cate);
                    Lib.Id_autor = ID_Autor;
                    Lib.Id_Editorial = ID_Editorial;
                    Lib.Numero_edicion = int.Parse(txtNumero_de_Edicion.Text);
                    Lib.estado = 0;
                    db.Libros.Add(Lib);
                    db.SaveChanges();
                    limpiar();
                    frmPrincipal.Lib.CargaDatos();
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
          
            if (indi !=0)
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
            frmBuscarEditoriales edi = new frmBuscarEditoriales();
            edi.ShowDialog();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

           ID_Cate = cmbCategoria.SelectedValue.ToString();


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtAutor.Text != "" && txtCantidad.Text != ""
               && txtEditorial.Text != "" && txtNumero_de_Edicion.Text != "" && int.Parse(txtCantidad.Text) > 0)
            {
                using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                {
                    Lib = db.Libros.First(buscarid => buscarid.Id_libro== ID_Libro);
                    Lib.Nombre = txtNombre.Text;
                    Lib.cantidad = int.Parse(txtCantidad.Text);
                    Lib.Año = Convert.ToDateTime(dtpAño.Text);
                    Lib.Id_categoria = int.Parse(ID_Cate);
                    Lib.Id_autor = ID_Autor;
                    Lib.Id_Editorial = ID_Editorial;
                    Lib.Numero_edicion = int.Parse(txtNumero_de_Edicion.Text);
                    Lib.estado = 0;
                    db.Entry(Lib).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    limpiar();
                    frmPrincipal.Lib.CargaDatos();
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
                    Lib = db.Libros.First(buscarid => buscarid.Id_libro == ID_Libro);
                    Lib.Nombre = txtNombre.Text;
                    Lib.cantidad = int.Parse(txtCantidad.Text);
                    Lib.Año = Convert.ToDateTime(dtpAño.Text);
                    Lib.Id_categoria = int.Parse(ID_Cate);
                    Lib.Id_autor = ID_Autor;
                    Lib.Id_Editorial = ID_Editorial;
                    Lib.Numero_edicion = int.Parse(txtNumero_de_Edicion.Text);
                    Lib.estado = 1;
                    db.Entry(Lib).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    limpiar();
                    frmPrincipal.Lib.CargaDatos();
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
