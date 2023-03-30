using AdminLabrary.View.buscar;
using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.Model;
using AdminLabrary.formularios.principales;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class frmAlquileresCRUD : Form
    {
        public int IdEntregado;
        public int idAlquiler;
        public int IdLibro;
        public int idLector;
        public int idAdmin;
        public int cantidad;
        public int indicador = 1;
        public DateTime fecha_salida;
        public DateTime fecha_pre;
        public int solicitud;
        public frmAlquileresCRUD()
        {
            InitializeComponent();
        }
        
        private void btnSeleccionarLibro_Click(object sender, EventArgs e)
        {
            frmBuscarLibros li = new frmBuscarLibros();
            li.ShowDialog();
        }
       
        private void btnSeleccionarLector_Click(object sender, EventArgs e)
        {
            frmBuscarLector lec = new frmBuscarLector();
            lec.indicador = 2;
            lec.filtro();
            lec.ShowDialog();
        }
    
        
        private void frmAlquileresCRUD_Load(object sender, EventArgs e)
        {
            
        }
        Alquileres alqu = new Alquileres();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (solicitud == 0)
            {


                if (txtLector.Text != "" && txtLibro.Text != "" && int.Parse(txtCantidad.Text) > 0)
                {
                    if  (int.Parse(txtCantidad.Text) <= cantidad)     
                    {

                        using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                        {
                            var lista = from lis in db.Libros
                                        where lis.Id_libro == IdLibro
                                        select new
                                        {
                                            cantidad = lis.cantidad
                                        };
                            foreach (var i in lista)
                            {
                                cantidad = i.cantidad;
                            }

                            if (cantidad >= int.Parse(txtCantidad.Text))
                            {
                                Alquileres alquiler = new Alquileres
                                {
                                    Id_Lector = idLector,
                                    Id_libro = IdLibro,
                                    Entregado = idAdmin,
                                    cantidad = int.Parse(txtCantidad.Text),
                                    fecha_salida = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")),
                                    fecha_prevista_de_entrega = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(8)
                                };
                                db.Alquileres.Add(alquiler);
                                db.SaveChanges();
                                frmPrincipal.prestamos.CargarDatos();
                                limpiar();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("La cantidad de libros en existencia es: " + cantidad.ToString());
                            }

                        }

                    }else
                    {
                        MessageBox.Show("La cantidad ingresada sobrepasa al limite permitido.\r" +
                            "El limite es: " + cantidad.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Todos los campos son obligatorios");
                }



            }
            else
            {
                if (txtLector.Text != "" && txtLibro.Text != "" && int.Parse(txtCantidad.Text) > 0)
                {

                    using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                    {
                        var lista = from lis in db.Libros
                                    where lis.Id_libro == IdLibro
                                    select new
                                    {
                                        cantidad = lis.cantidad
                                    };
                        foreach (var i in lista)
                        {
                            cantidad = i.cantidad;
                        }

                        if (cantidad >= int.Parse(txtCantidad.Text))
                        {
                            Alquileres alquiler = new Alquileres
                            {
                                Id_Lector = idLector,
                                Id_libro = IdLibro,
                                Entregado = idAdmin,
                                cantidad = int.Parse(txtCantidad.Text),
                                fecha_salida = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")),
                                fecha_prevista_de_entrega = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(8)
                            };
                            db.Alquileres.Add(alquiler);
                            db.SaveChanges();
                            frmPrincipal.prestamos.CargarDatos();
                            
                            solicitudes soli = new solicitudes();
                            soli = db.solicitudes.First(buscarID => buscarID.id_soli == solicitud);
                            soli.Cantidad = int.Parse(txtCantidad.Text);
                            soli.libros = IdLibro;
                            soli.id_lector = idLector;
                            soli.estado = 1;
                            db.Entry(soli).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            solicitud = 0;
                            limpiar();
                            frmPrincipal.Sol.CargarDatos();
                            Close();

                        }
                        else
                        {
                            MessageBox.Show("La cantidad de libros en existencia es: " + cantidad.ToString());
                        }

                    }

                }
            }
            frmPrincipal.prestamos.ultimafila();
        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                if (int.Parse(txtCantidad.Text) > cantidad || int.Parse(txtCantidad.Text) <= 0)
                {
                    MessageBox.Show("Cantidad incorrecta");
                }
                else if (int.Parse(txtCantidad.Text) < cantidad && int.Parse(txtCantidad.Text) > 0)
                {
                    alqu = db.Alquileres.First(buscarID => buscarID.Id_alquiler == idAlquiler);
                    alqu.Id_Lector = idLector;
                    alqu.Id_libro = IdLibro;
                    alqu.cantidad = Int32.Parse(txtCantidad.Text);
                    alqu.Entregado = IdEntregado;
                    alqu.fecha_salida = fecha_salida;
                    alqu.fecha_prevista_de_entrega = fecha_pre;
                    alqu.fecha_de_entrega = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    alqu.Recibido = idAdmin;
                    db.Entry(alqu).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Alquileres alqui = new Alquileres
                    {
                        Id_Lector = idLector,
                        Id_libro = IdLibro,
                        cantidad = cantidad - int.Parse(txtCantidad.Text),
                        Entregado = IdEntregado,
                        fecha_salida = fecha_salida,
                        fecha_prevista_de_entrega = fecha_pre
                    };
                    db.Alquileres.Add(alqui);
                    db.SaveChanges();
                }
                else if (int.Parse(txtCantidad.Text) == cantidad && int.Parse(txtCantidad.Text) > 0)
                {
                    alqu = db.Alquileres.First(buscarID => buscarID.Id_alquiler == idAlquiler);
                    alqu.Id_Lector = idLector;
                    alqu.Id_libro = IdLibro;
                    alqu.cantidad = int.Parse(txtCantidad.Text);
                    alqu.Entregado = IdEntregado;
                    alqu.fecha_salida = fecha_salida;
                    alqu.fecha_prevista_de_entrega = fecha_pre;
                    alqu.fecha_de_entrega = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    alqu.Recibido = idAdmin;
                    db.Entry(alqu).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }



            }
            limpiar();
            frmPrincipal.prestamos.CargarDatos();
            Close();
            frmPrincipal.prestamos.ultimafila();
        }
        public void limpiar()
        {

            txtLector.Text = "";
            txtLibro.Text = "";
            txtCantidad.Text = "";
            IdEntregado = 0;
            idAlquiler = 0;
            IdLibro = 0;
            idLector = 0;
            
           

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
    
    }
}
