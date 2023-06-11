using AdminLabrary.Model;
using AdminLabrary.View.buscar;
using AdminLabrary.View.principales;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.insertUpdateDelete
{
    public partial class FrmAlquileresCrud : Form
    {
        private Alquileres _alqu = new Alquileres();

        public int IdEntregado;
        public int IdAlquiler;
        public int IdLibro;
        public int IdLector;
        public int IdAdmin;
        public int Cantidad;
        public int Indicador = 1;
        public DateTime FechaSalida;
        public DateTime FechaPre;
        public int Solicitud;

        public FrmAlquileresCrud()
        {
            InitializeComponent();
        }

        private void btnSeleccionarLibro_Click(object sender, EventArgs e)
        {
            FrmBuscarLibros li = new FrmBuscarLibros();
            li.ShowDialog();
        }

        private void btnSeleccionarLector_Click(object sender, EventArgs e)
        {
            FrmBuscarLector lec = new FrmBuscarLector();
            lec.Indicador = 2;
            lec.Filtro();
            lec.ShowDialog();
        }

        private void frmAlquileresCRUD_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Solicitud == 0)
            {
                if (!string.IsNullOrWhiteSpace(txtLector.Text) && !string.IsNullOrWhiteSpace(txtLibro.Text) && int.Parse(txtCantidad.Text) > 0)
                {
                    if (int.Parse(txtCantidad.Text) <= Cantidad)
                    {
                        using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                        {
                            var lista = from lis in db.Libros
                                        where lis.Id_libro == IdLibro
                                        select new
                                        {
                                            lis.cantidad
                                        };

                            foreach (var i in lista)
                            {
                                Cantidad = i.cantidad;
                            }

                            if (Cantidad >= int.Parse(txtCantidad.Text))
                            {
                                Alquileres alquiler = new Alquileres
                                {
                                    Id_Lector = IdLector,
                                    Id_libro = IdLibro,
                                    Entregado = IdAdmin,
                                    cantidad = int.Parse(txtCantidad.Text),
                                    fecha_salida = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")),
                                    fecha_prevista_de_entrega = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(8)
                                };

                                db.Alquileres.Add(alquiler);
                                db.SaveChanges();
                                FrmPrincipal.Prestamos.CargarDatos();
                                Limpiar();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("La cantidad de libros en existencia es: " + Cantidad.ToString());
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad ingresada sobrepasa el límite permitido.\r" +
                            "El límite es: " + Cantidad.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Todos los campos son obligatorios");
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtLector.Text) && !string.IsNullOrWhiteSpace(txtLibro.Text) && int.Parse(txtCantidad.Text) > 0)
                {
                    using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
                    {
                        var lista = from lis in db.Libros
                                    where lis.Id_libro == IdLibro
                                    select new
                                    {
                                        lis.cantidad
                                    };

                        foreach (var i in lista)
                        {
                            Cantidad = i.cantidad;
                        }

                        if (Cantidad >= int.Parse(txtCantidad.Text))
                        {
                            Alquileres alquiler = new Alquileres
                            {
                                Id_Lector = IdLector,
                                Id_libro = IdLibro,
                                Entregado = IdAdmin,
                                cantidad = int.Parse(txtCantidad.Text),
                                fecha_salida = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")),
                                fecha_prevista_de_entrega = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(8)
                            };

                            db.Alquileres.Add(alquiler);
                            db.SaveChanges();
                            FrmPrincipal.Prestamos.CargarDatos();

                            var soli = db.solicitudes.First(buscarId => buscarId.id_soli == Solicitud);
                            soli.Cantidad = int.Parse(txtCantidad.Text);
                            soli.libros = IdLibro;
                            soli.id_lector = IdLector;
                            soli.estado = 1;
                            db.Entry(soli).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();

                            Solicitud = 0;
                            Limpiar();
                            FrmPrincipal.Sol.CargarDatos();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("La cantidad de libros en existencia es: " + Cantidad.ToString());
                        }
                    }
                }
            }

            FrmPrincipal.Prestamos.Ultimafila();
        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                if (int.Parse(txtCantidad.Text) > Cantidad || int.Parse(txtCantidad.Text) <= 0)
                {
                    MessageBox.Show("Cantidad incorrecta");
                }
                else if (int.Parse(txtCantidad.Text) < Cantidad && int.Parse(txtCantidad.Text) > 0)
                {
                    _alqu = db.Alquileres.First(buscarId => buscarId.Id_alquiler == IdAlquiler);
                    _alqu.Id_Lector = IdLector;
                    _alqu.Id_libro = IdLibro;
                    _alqu.cantidad = Int32.Parse(txtCantidad.Text);
                    _alqu.Entregado = IdEntregado;
                    _alqu.fecha_salida = FechaSalida;
                    _alqu.fecha_prevista_de_entrega = FechaPre;
                    _alqu.fecha_de_entrega = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    _alqu.Recibido = IdAdmin;
                    db.Entry(_alqu).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    Alquileres alqui = new Alquileres
                    {
                        Id_Lector = IdLector,
                        Id_libro = IdLibro,
                        cantidad = Cantidad - int.Parse(txtCantidad.Text),
                        Entregado = IdEntregado,
                        fecha_salida = FechaSalida,
                        fecha_prevista_de_entrega = FechaPre
                    };

                    db.Alquileres.Add(alqui);
                    db.SaveChanges();
                }
                else if (int.Parse(txtCantidad.Text) == Cantidad && int.Parse(txtCantidad.Text) > 0)
                {
                    _alqu = db.Alquileres.First(buscarId => buscarId.Id_alquiler == IdAlquiler);
                    _alqu.Id_Lector = IdLector;
                    _alqu.Id_libro = IdLibro;
                    _alqu.cantidad = int.Parse(txtCantidad.Text);
                    _alqu.Entregado = IdEntregado;
                    _alqu.fecha_salida = FechaSalida;
                    _alqu.fecha_prevista_de_entrega = FechaPre;
                    _alqu.fecha_de_entrega = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    _alqu.Recibido = IdAdmin;
                    db.Entry(_alqu).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }

            Limpiar();
            FrmPrincipal.Prestamos.CargarDatos();
            Close();
            FrmPrincipal.Prestamos.Ultimafila();
        }

        public void Limpiar()
        {
            txtLector.Text = "";
            txtLibro.Text = "";
            txtCantidad.Text = "";
            IdEntregado = 0;
            IdAlquiler = 0;
            IdLibro = 0;
            IdLector = 0;
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
