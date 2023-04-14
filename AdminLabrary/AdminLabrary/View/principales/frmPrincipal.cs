using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AdminLabrary.View.principales
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
          




        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Form _activeForm;


        public void MostrarPanel(Form panel)
        {
            if (_activeForm != null)
                _activeForm = panel;
            panel.TopLevel = false;
            panel.FormBorderStyle = FormBorderStyle.None;
            panel.Dock = DockStyle.Fill;
            pPrincipal.Controls.Add(panel);
            pPrincipal.Tag = panel;
            panel.BringToFront();
            panel.Show();
        }


        public static FrmEditorial Editorial = new FrmEditorial();
        private void btnProductos_Click(object sender, EventArgs e)
        {
            _color = 5;
            Cambiarcolor();
            MostrarPanel(Editorial);

        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult resu = MessageBox.Show("¿Desea salir de la aplicacion?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (resu == DialogResult.Yes)
            {
                Application.Exit();
            }

        }


        int _boton;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (_boton == 0)
            {
                WindowState = FormWindowState.Maximized;
                btnMaximizar.Visible = true;
                btnMinimizar.Visible = true;
                _boton = 1;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                btnMinimizar.Visible = true;
                btnMaximizar.Visible = true;
                _boton = 0;
            }

        }

        private void btnMinimizar_Click(object sender, EventArgs e)

        {
            WindowState = FormWindowState.Minimized;

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private static extern void SendMessage(IntPtr hWnd, int wMsg, int lParam, int v);

        private void PanelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);


        }

        private void PanelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }


        private void PanelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        public static FrmAdministradores Admin = new FrmAdministradores();
        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            _color = 3;
            Cambiarcolor();
            MostrarPanel(Admin);
        }


        public static FrmLectores Lector = new FrmLectores();
        private void btnLectores_Click(object sender, EventArgs e)
        {
            _color = 8;
            Cambiarcolor();
            MostrarPanel(Lector);

        }
        public static FrmCategoria Categoria = new FrmCategoria();
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            _color = 4;
            Cambiarcolor();
            MostrarPanel(Categoria);

        }
        public static FrmLibros Lib = new FrmLibros();
        private void btnLibros_Click(object sender, EventArgs e)
        {
            _color = 2;
            Cambiarcolor();
            Lib.CargaDatos();

            MostrarPanel(Lib);

        }

        int _color;
        void Cambiarcolor()
        {
            if(_color == 0)
            {
                btnPrestamos.BackColor = Color.Teal;
                btnSolicitudes.BackColor = Color.FromArgb(64,64,64,64);
                btnLibros.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAdmin.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnCategoria.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnEditorial.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAutor.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnRoles.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLectores.BackColor = Color.FromArgb(64, 64, 64, 64);
            }else if (_color == 1)
            {
                btnPrestamos.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnSolicitudes.BackColor = Color.Teal;
                btnLibros.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAdmin.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnCategoria.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnEditorial.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAutor.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnRoles.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLectores.BackColor = Color.FromArgb(64, 64, 64, 64);
            }
            else if (_color == 2)
            {
                btnPrestamos.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnSolicitudes.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLibros.BackColor = Color.Teal;
                btnAdmin.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnCategoria.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnEditorial.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAutor.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnRoles.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLectores.BackColor = Color.FromArgb(64, 64, 64, 64);
            }
            else if (_color == 3)
            {
                btnPrestamos.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnSolicitudes.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLibros.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAdmin.BackColor = Color.Teal;
                btnCategoria.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnEditorial.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAutor.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnRoles.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLectores.BackColor = Color.FromArgb(64, 64, 64, 64);
            }
            else if (_color == 4)
            {
                btnPrestamos.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnSolicitudes.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLibros.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAdmin.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnCategoria.BackColor = Color.Teal;
                btnEditorial.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAutor.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnRoles.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLectores.BackColor = Color.FromArgb(64, 64, 64, 64);
            }
            else if (_color == 5)
            {
                btnPrestamos.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnSolicitudes.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLibros.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAdmin.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnCategoria.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnEditorial.BackColor = Color.Teal;
                btnAutor.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnRoles.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLectores.BackColor = Color.FromArgb(64, 64, 64, 64);
            }
            else if (_color == 6)
            {
                btnPrestamos.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnSolicitudes.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLibros.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAdmin.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnCategoria.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnEditorial.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAutor.BackColor = Color.Teal;
                btnRoles.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLectores.BackColor = Color.FromArgb(64, 64, 64, 64);
            }
            else if (_color == 7)
            {
                btnPrestamos.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnSolicitudes.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLibros.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAdmin.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnCategoria.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnEditorial.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAutor.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnRoles.BackColor = Color.Teal;
                btnLectores.BackColor = Color.FromArgb(64, 64, 64, 64);
            }
            else if (_color == 8)
            {
                btnPrestamos.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnSolicitudes.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLibros.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAdmin.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnCategoria.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnEditorial.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAutor.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnRoles.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLectores.BackColor = Color.Teal;
            }
            else if (_color == 9)
            {
                btnPrestamos.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnSolicitudes.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLibros.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAdmin.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnCategoria.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnEditorial.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnAutor.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnRoles.BackColor = Color.FromArgb(64, 64, 64, 64);
                btnLectores.BackColor = Color.FromArgb(64, 64, 64, 64);
            }

        }

        public static FrmPrestamos Prestamos = new FrmPrestamos();
        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            _color = 0;
            Cambiarcolor();
            MostrarPanel(Prestamos);


        }

        public static FrmAutor Autor = new FrmAutor();
        private void btnAutor_Click(object sender, EventArgs e)
        {
            _color = 6;
            Cambiarcolor();
            MostrarPanel(Autor);
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            PanelMenu.Hide();
            picce2.Show();
            btnMostrar.Show();
        }

        public void btnMostrar_Click(object sender, EventArgs e)
        {
            PanelMenu.Show();
            picce2.Hide();  
            btnMostrar.Hide();
        }

      

       
         public static FrmRoles R = new FrmRoles();
        private void btnRoles_Click(object sender, EventArgs e)
        {
            _color = 7;
            R.CargarDatos();
            Cambiarcolor();
            MostrarPanel(R);
        }
        public static FrmSolicitudes Sol = new FrmSolicitudes();
        private void button2_Click(object sender, EventArgs e)
        {
            _color = 1;
            Cambiarcolor();
            Sol.CargarDatos();

            MostrarPanel(Sol);
        }

        public void PictureBox5_Click(object sender, EventArgs e)
        {
            picLogo.BringToFront();
            _color = 9;
            Cambiarcolor();
        }
        public void Inicio()
        {
            picLogo.BringToFront();
            _color = 9;
            Cambiarcolor();
        }
        public int Rol;
        public void Roles()
        {
            if (Rol == 0)
            {
                Lib.dgvLibros.Columns["NUEVO"].Visible = false;
                Lib.dgvLibros.Columns["EDITAR"].Visible = false;
                Lib.dgvLibros.Columns["ELIMINAR"].Visible = false;
                btnPrestamos.Hide();
                btnAdmin.Hide();
                btnCategoria.Hide();
                btnAutor.Hide();
                btnEditorial.Hide();
                btnRoles.Hide();
                btnLectores.Hide();
            }
            else
            {
                Lib.dgvLibros.Columns["NUEVO"].Visible = true;
                Lib.dgvLibros.Columns["EDITAR"].Visible = true;
                Lib.dgvLibros.Columns["ELIMINAR"].Visible = true;
                btnPrestamos.Show();
                btnAdmin.Show();
                btnCategoria.Show();
                btnAutor.Show();
                btnEditorial.Show();
                btnRoles.Show();
                btnLectores.Show();
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Hide();
            FrmLogin login = new FrmLogin();
            login.Show();
        }
    }

}

