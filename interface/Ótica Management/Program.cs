using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ótica_Management
{
    internal static class Program
    {

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {

                // Login bem-sucedido, abra a MainPage
                Application.Run(new MainPage());
            }
        }
    }
}