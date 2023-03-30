using System;
using System.Windows.Forms;
using AdminLabrary.View.principales;

namespace AdminLabrary
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin login = new frmLogin();
            login.Show();
            Application.Run();
        }
    }
}
