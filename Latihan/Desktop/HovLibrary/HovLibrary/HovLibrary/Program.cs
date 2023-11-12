using HovLibrary.Controllers;
using HovLibrary.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AuthController auth = new AuthController();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (auth.isLoggedIn()) 
            { 
                Application.Run(new FormMain());
            } else
            {
                Application.Run(new FormLogin());
            }
        }
    }
}
