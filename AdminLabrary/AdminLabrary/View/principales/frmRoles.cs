using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdminLabrary.View.principales
{
    public partial class FrmRoles : Form
    {
        public FrmRoles()
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
                                ad.Usuario,
                                ad.Contraseña,
                                IDLector = lec.Id_Lector,
                                rol = ad.Rol,
                                roln = ad.Rol
                            };
                foreach (var i in lista)
                {
                    // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
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

        public FrmAdministradoresCrud Admin = new FrmAdministradoresCrud();




        private void dgvAdmi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void Seleccionar()
        {
            string id = dgvAdmi.CurrentRow.Cells[0].Value.ToString();
            string usuario = dgvAdmi.CurrentRow.Cells[1].Value.ToString();
            string contraseña = dgvAdmi.CurrentRow.Cells[2].Value.ToString();
            string idU = dgvAdmi.CurrentRow.Cells[4].Value.ToString();
            string lector = dgvAdmi.CurrentRow.Cells[3].Value.ToString();
            int idR = int.Parse(dgvAdmi.CurrentRow.Cells[6].Value.ToString());
            if (idR == 0)
            {
                Admin.rbtnLector.Checked = true;
            }
            else
            {
                Admin.rbtnAdmi.Checked = true;
            }
            Admin.txtLector.Text = lector;
            Admin.IdLector = int.Parse(idU);
            Admin.txtUsuario.Text = usuario;
            Admin.IdAdmin = int.Parse(id);
        }

        private void dgvAdmi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAdmi.Columns["NUEVO"].Index && e.RowIndex != -1)
            {
                Admin.btnGuardar.Show();
                Admin.btnGuardar.Enabled = true;
                Admin.btnEditar.Hide();
                Admin.btnEliminar.Hide();
                Admin.btnSeleccionar.Show();
                Admin.btnGuardar.Show();
                Admin.rbtnLector.Checked = true;
                Admin.Limpiar();
                Admin.ShowDialog();
                Admin.btnSeleccionar.Visible = true;
            }
            else if (e.ColumnIndex == dgvAdmi.Columns["EDITAR"].Index && e.RowIndex != -1)
            {
                Admin.btnGuardar.Hide();
                Admin.btnEditar.Show();
                Admin.btnEliminar.Hide();
                Admin.btnEditar.Enabled = true;
                Admin.btnSeleccionar.Enabled = true;
                Admin.rbtnAdmi.Checked = true;
                Seleccionar();
                Admin.ShowDialog();
            }
            else if (e.ColumnIndex == dgvAdmi.Columns["ELIMINAR"].Index && e.RowIndex != -1)
            {
                Admin.btnGuardar.Hide();
                Admin.btnEliminar.Show();
                Admin.btnEditar.Hide();
                Admin.btnEliminar.Enabled = true;
                Admin.btnSeleccionar.Hide();
                Admin.txtContraseña.Enabled = false;
                Admin.txtUsuario.Enabled = false;
                Admin.rbtnAdmi.Checked = true;
                Seleccionar();
                Admin.ShowDialog();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

