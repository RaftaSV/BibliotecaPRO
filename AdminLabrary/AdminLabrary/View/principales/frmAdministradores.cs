
using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.Model;
using AdminLabrary.View.insertUpdateDelete;

namespace AdminLabrary.formularios.principales
{
    public partial class frmAdministradores : Form
    {
        public frmAdministradores()
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
                                Usuario = ad.Usuario,
                                Contraseña = ad.Contraseña,
                                IDLector = lec.Id_Lector
                            };
                foreach(var i in lista)
                {
                    dgvAdmi.Rows.Add(i.ID,i.Usuario,i.Contraseña,i.Nombre,i.IDLector);
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
            admin.txtLector.Text = lector;
            admin.txtContraseña.Text = contraseña;
            admin.IDLector = int.Parse(idU);
            admin.txtUsuario.Text = usuario;
            admin.IDAdmin = int.Parse(Id);
        }

        private void dgvAdmi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAdmi.Columns["EDITAR"].Index && e.RowIndex != -1)
            {
                if (dgvAdmi.RowCount > 0)
                {
                    admin.btnEditar.Show();
                    admin.btnEliminar.Hide();
                    admin.btnSeleccionar.Show();
                    admin.btnGuardar.Hide();
                    admin.btnEditar.Show();
                    admin.btnEditar.Enabled = true;
                    admin.rbtnAdmi.Checked = true;
                    Seleccionar();
                    admin.btnSeleccionar.Visible = false;
                    admin.ShowDialog();
                }
            }
        }
    }
}
