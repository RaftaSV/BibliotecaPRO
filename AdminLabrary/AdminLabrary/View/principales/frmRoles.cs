using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminLabrary.View.principales
{
    public partial class frmRoles : Form
    {
        public frmRoles()
        {
            InitializeComponent();
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        public void CargarDatos()
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                dgvAdmi.Rows.Clear();
                var lista = from ad in db.Roles
                            from lec in db.Lectores
                            where ad.Id_Lector == lec.Id_Lector
                            && lec.estado == 0
                            && ad.estado == 0

                            select new
                            {
                                ID = ad.Id_rol,
                                Nombre = lec.Nombres,
                                Usuario = ad.Usuario,
                                Contraseña = ad.Contraseña,
                                IDLector = lec.Id_Lector,
                                rol = ad.Rol,
                                roln = ad.Rol
                            };
                foreach (var i in lista)
                {
                    if (i.rol == 0)
                    {
                        dgvAdmi.Rows.Add(i.ID, i.Usuario, i.Contraseña, i.Nombre, i.IDLector, "Lector", i.rol);
                    }
                    else
                    {
                        dgvAdmi.Rows.Add(i.ID, i.Usuario, i.Contraseña, i.Nombre, i.IDLector, "Admin", i.rol);
                    }


                }

            }

        }

        public frmAdministradoresCRUD admin = new frmAdministradoresCRUD();




        private void dgvAdmi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void Seleccionar()
        {
            string Id = dgvAdmi.CurrentRow.Cells[0].Value.ToString();
            string usuario = dgvAdmi.CurrentRow.Cells[1].Value.ToString();
            string contraseña = dgvAdmi.CurrentRow.Cells[2].Value.ToString();
            string idU = dgvAdmi.CurrentRow.Cells[4].Value.ToString();
            string lector = dgvAdmi.CurrentRow.Cells[3].Value.ToString();
            int idR = int.Parse(dgvAdmi.CurrentRow.Cells[6].Value.ToString());
            if (idR == 0)
            {
                admin.rbtnLector.Checked = true;
            }
            else
            {
                admin.rbtnAdmi.Checked = true;
            }
            admin.txtLector.Text = lector;
            admin.txtContraseña.Text = contraseña;
            admin.IDLector = int.Parse(idU);
            admin.txtUsuario.Text = usuario;
            admin.IDAdmin = int.Parse(Id);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dgvAdmi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dgvAdmi.Columns["NUEVO"].Index && e.RowIndex != -1)
                {
                    admin.btnGuardar.Show();
                    admin.btnGuardar.Enabled = true;
                    admin.btnEditar.Hide();
                    admin.btnEliminar.Hide();
                    admin.btnSeleccionar.Show();
                    admin.btnGuardar.Show();
                    admin.rbtnLector.Checked = true;
                    admin.Limpiar();
                    admin.ShowDialog();
                admin.btnSeleccionar.Visible = true;
            }
                else if (e.ColumnIndex == this.dgvAdmi.Columns["EDITAR"].Index && e.RowIndex != -1)
                {
                    admin.btnGuardar.Hide();
                    admin.btnEditar.Show();
                    admin.btnEliminar.Hide();
                    admin.btnEditar.Enabled = true;
                    admin.btnSeleccionar.Enabled = true;
                    admin.rbtnAdmi.Checked = true;
                    Seleccionar();
                    admin.ShowDialog();
                }
                else if (e.ColumnIndex == this.dgvAdmi.Columns["ELIMINAR"].Index && e.RowIndex != -1)
                {
                    admin.btnGuardar.Hide();
                    admin.btnEliminar.Show();
                    admin.btnEditar.Hide();
                    admin.btnEliminar.Enabled = true;
                    admin.btnSeleccionar.Hide();
                    admin.txtContraseña.Enabled = false;
                    admin.txtUsuario.Enabled = false;
                    admin.rbtnAdmi.Checked = true;
                    Seleccionar();
                    admin.ShowDialog();
                }
            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    }

