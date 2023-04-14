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
            FrmLogin login = new FrmLogin();
            login.Show();
            Application.Run();
        }
    }
}
