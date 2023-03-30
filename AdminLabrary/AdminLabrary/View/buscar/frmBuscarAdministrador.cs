using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.formularios.principales;
using AdminLabrary.Model;

namespace AdminLabrary.View.buscar
{
    public partial class frmBuscarAdministrador : Form
    {
        public frmBuscarAdministrador()
        {
            InitializeComponent();
            filtro();
                
        }

        private void frmBuscarAdministrador_Load(object sender, EventArgs e)
        {

        }
        void filtro()
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                dgvAdministrador.Rows.Clear();
                string buscar = txtBuscar.Text;
                var ListaA = from Adm in db.Roles
                             where Adm.Usuario.Contains(buscar)
                             && Adm.estado==0
                             select new
                             {
                                 ID = Adm.Id_rol,
                                 Usuario = Adm.Usuario,
                                 Contraseña = Adm.Contraseña,
                                 rol = Adm.Rol
                             };
                foreach (var iterar in ListaA)
                {
                    // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                    if (iterar.rol != 0)
                    {
                        dgvAdministrador.Rows.Add(iterar.ID, iterar.Usuario, iterar.Contraseña, "Admin");
                    }
                    else
                    {
                        dgvAdministrador.Rows.Add(iterar.ID, iterar.Usuario, iterar.Contraseña, "Lector");
                    }
                }
            }
        }

        public int indicador;

        void seleccionar()
        {
            string Id = dgvAdministrador.CurrentRow.Cells[0].Value.ToString();
            string Nombre = dgvAdministrador.CurrentRow.Cells[1].Value.ToString();
            if (indicador == 1)
            {
                frmPrincipal.admin.admin.txtLector.Text = Nombre;
                frmPrincipal.admin.admin.IDLector = int.Parse(Id);
                Close();
            }
        }

        private void dgvAdministrador_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionar();
        }

        private void dgvAdministrador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                seleccionar();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }
    }
}
