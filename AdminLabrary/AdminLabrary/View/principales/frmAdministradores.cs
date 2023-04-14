using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;

namespace AdminLabrary.View.principales
{
    public partial class FrmAdministradores : Form
    {
        public FrmAdministradores()
        {
            InitializeComponent();
        }

        private void Carreras_Load(object sender, EventArgs e)
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
                            && ad.estado==0
                            && ad.Rol == 1
                            select new
                            {
                                ID = ad.Id_rol,
                                Nombre = lec.Nombres,
                                ad.Usuario,
                                ad.Contraseña,
                                IDLector = lec.Id_Lector
                            };
                foreach(var i in lista)
                {
                    dgvAdmi.Rows.Add(i.ID,i.Usuario,i.Contraseña,i.Nombre,i.IDLector);
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
            Admin.txtLector.Text = lector;
            Admin.txtContraseña.Text = contraseña;
            Admin.IdLector = int.Parse(idU);
            Admin.txtUsuario.Text = usuario;
            Admin.IdAdmin = int.Parse(id);
        }

        private void dgvAdmi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAdmi.Columns["EDITAR"].Index && e.RowIndex != -1)
            {
                if (dgvAdmi.RowCount > 0)
                {
                    Admin.btnEditar.Show();
                    Admin.btnEliminar.Hide();
                    Admin.btnSeleccionar.Show();
                    Admin.btnGuardar.Hide();
                    Admin.btnEditar.Show();
                    Admin.btnEditar.Enabled = true;
                    Admin.rbtnAdmi.Checked = true;
                    Seleccionar();
                    Admin.btnSeleccionar.Visible = false;
                    Admin.ShowDialog();
                }
            }
        }
    }
}
