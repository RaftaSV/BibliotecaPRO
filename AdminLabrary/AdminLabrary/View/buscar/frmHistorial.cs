using AdminLabrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminLabrary.View.buscar
{
    public partial class frmHistorial : Form
    {
        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            filtro();
        }
        public void filtro()
        {
            dgvAlquiler.Rows.Clear();
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                string buscar = txtBuscar.Text;

                var lista = from al in db.Alquileres
                            from lec in db.Lectores
                            from li in db.Libros
                            from adm in db.Roles
                            where al.Id_Lector == lec.Id_Lector
                            && al.Id_libro == li.Id_libro
                            && al.Entregado == adm.Id_rol
                            && lec.Nombres.Contains(buscar)


                            select new
                            {
                                ID = al.Id_alquiler,
                                Lector = lec.Nombres,
                                Libro = li.Nombre,
                                entregado = adm.Usuario,
                                fechaS = al.fecha_salida,
                                fechaP = al.fecha_prevista_de_entrega,
                                fecha = al.fecha_de_entrega,
                                recibido = al.Recibido
                            };
                foreach (var i in lista)
                {
                    DateTime fechasalida = i.fechaS;
                    DateTime fechaPre = i.fechaP;
                    TimeSpan con = DateTime.Now - fechaPre;

                    if (i.recibido == null)
                    {
                        if (int.Parse(con.Days.ToString()) > 0)
                        {
                            dgvAlquiler.Rows.Add(i.ID, i.Lector, i.Libro, i.entregado, "Pendiente", con.Days);
                        }
                    }
                    else
                    {
                        DateTime fechaentrega = i.fecha.Value;
                        TimeSpan contadorEn = fechaPre - fechaentrega;
                        if (contadorEn.Days < 0)
                        {
                            dgvAlquiler.Rows.Add(i.ID, i.Lector, i.Libro, i.entregado, "Entregado", -contadorEn.Days);
                        }
                    }
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void dgvAlquiler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
