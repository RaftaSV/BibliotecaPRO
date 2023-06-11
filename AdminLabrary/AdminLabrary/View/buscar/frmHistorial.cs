using AdminLabrary.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.buscar
{
    public partial class FrmHistorial : Form
    {
        public FrmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Filtro();
        }
        public void Filtro()
        {
            dgvAlquiler.Rows.Clear();
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                string buscar = txtBuscar.Text;

                var lista = from al in db.Alquileres
                            join lec in db.Lectores on al.Id_Lector equals lec.Id_Lector
                            join li in db.Libros on al.Id_libro equals li.Id_libro
                            join adm in db.Roles on al.Entregado equals adm.Id_rol
                            where lec.Nombres.Contains(buscar)
                            select new
                            {
                                ID = al.Id_alquiler,
                                Lector = lec.Nombres,
                                Libro = li.Nombre,
                                Entregado = adm.Usuario,
                                FechaS = al.fecha_salida,
                                FechaP = al.fecha_prevista_de_entrega,
                                Fecha = al.fecha_de_entrega,
                                Recibido = al.Recibido
                            };

                foreach (var i in lista)
                {
                    DateTime fechaPre = i.FechaP;
                    TimeSpan con = DateTime.Now - fechaPre;

                    if (i.Recibido == null)
                    {
                        if (con.Days > 0)
                        {
                            dgvAlquiler.Rows.Add(i.ID, i.Lector, i.Libro, i.Entregado, "Pendiente", con.Days);
                        }
                    }
                    else
                    {
                        DateTime fechaEntrega = i.Fecha.Value;
                        TimeSpan contadorEn = fechaPre - fechaEntrega;
                        if (contadorEn.Days < 0)
                        {
                            dgvAlquiler.Rows.Add(i.ID, i.Lector, i.Libro, i.Entregado, "Entregado", -contadorEn.Days);
                        }
                    }
                }
            }
        }


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Filtro();
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
