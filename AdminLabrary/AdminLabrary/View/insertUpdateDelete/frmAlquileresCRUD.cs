using AdminLabrary.View.buscar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminLabrary.Model;
using AdminLabrary.formularios.principales;
using System.Windows.Forms.ComponentModel.Com2Interop;

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
        public int solicitud =0;
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
                                Alquileres alquiler = new Alquileres();
                                alquiler.Id_Lector = idLector;
                                alquiler.Id_libro = IdLibro;
                                alquiler.Entregado = idAdmin;
                                alquiler.cantidad = int.Parse(txtCantidad.Text);
                                alquiler.fecha_salida = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                                alquiler.fecha_prevista_de_entrega = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(8);
                                db.Alquileres.Add(alquiler);
                                db.SaveChanges();
                                frmPrincipal.prestamos.CargarDatos();
                                limpiar();
                                this.Close();
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
                            Alquileres alquiler = new Alquileres();
                            alquiler.Id_Lector = idLector;
                            alquiler.Id_libro = IdLibro;
                            alquiler.Entregado = idAdmin;
                            alquiler.cantidad = int.Parse(txtCantidad.Text);
                            alquiler.fecha_salida = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                            alquiler.fecha_prevista_de_entrega = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(8);
                            db.Alquileres.Add(alquiler);
                            db.SaveChanges();
                            frmPrincipal.prestamos.CargarDatos();
                            
                            solicitudes soli = new solicitudes();
                            soli = db.solicitudes.Where(buscarID => buscarID.id_soli == solicitud).First();
                            soli.Cantidad = int.Parse(txtCantidad.Text);
                            soli.libros = IdLibro;
                            soli.id_lector = idLector;
                            soli.estado = 1;
                            db.Entry(soli).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            solicitud = 0;
                            limpiar();
                            frmPrincipal.Sol.CargarDatos();
                            this.Close();

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
                    alqu = db.Alquileres.Where(buscarID => buscarID.Id_alquiler == idAlquiler).First();
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
                    Alquileres alqui = new Alquileres();
                    alqui.Id_Lector = idLector;
                    alqui.Id_libro = IdLibro;
                    alqui.cantidad = cantidad - int.Parse(txtCantidad.Text);
                    alqui.Entregado = IdEntregado;
                    alqui.fecha_salida = fecha_salida;
                    alqui.fecha_prevista_de_entrega = fecha_pre;
                    db.Alquileres.Add(alqui);
                    db.SaveChanges();
                }
                else if (int.Parse(txtCantidad.Text) == cantidad && int.Parse(txtCantidad.Text) > 0)
                {
                    alqu = db.Alquileres.Where(buscarID => buscarID.Id_alquiler == idAlquiler).First();
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
            this.Close();
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
