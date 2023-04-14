using System;
using System.Linq;
using System.Windows.Forms;
using AdminLabrary.Model;
using AdminLabrary.View.principales;

namespace AdminLabrary.View.buscar
{
    public partial class FrmBuscarAdministrador : Form
    {
        public FrmBuscarAdministrador()
        {
            InitializeComponent();
            Filtro();
                
        }

        private void frmBuscarAdministrador_Load(object sender, EventArgs e)
        {

        }
        void Filtro()
        {
            using (BibliotecaprogramEntities db = new BibliotecaprogramEntities())
            {
                dgvAdministrador.Rows.Clear();
                string buscar = txtBuscar.Text;
                var listaA = from adm in db.Roles
                             where adm.Usuario.Contains(buscar)
                             && adm.estado==0
                             select new
                             {
                                 ID = adm.Id_rol,
                                 adm.Usuario,
                                 adm.Contraseña,
                                 rol = adm.Rol
                             };
                foreach (var iterar in listaA)
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

        public int Indicador;

        void Seleccionar()
        {
            string id = dgvAdministrador.CurrentRow.Cells[0].Value.ToString();
            string nombre = dgvAdministrador.CurrentRow.Cells[1].Value.ToString();
            if (Indicador == 1)
            {
                FrmPrincipal.Admin.Admin.txtLector.Text = nombre;
                FrmPrincipal.Admin.Admin.IdLector = int.Parse(id);
                Close();
            }
        }

        private void dgvAdministrador_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }

        private void dgvAdministrador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Seleccionar();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Filtro();
        }
    }
}
