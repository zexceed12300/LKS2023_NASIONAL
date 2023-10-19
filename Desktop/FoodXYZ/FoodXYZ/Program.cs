using FoodXYZ.Controllers;
using FoodXYZ.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodXYZ
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AuthController authController = new AuthController();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (authController.isLoggedIn())
            {
                switch (authController.getUserLoggedIn().tipe_user)
                {
                    case "admin":
                        Application.Run(new FormAdmin());
                        break;
                    case "gudang":
                        Application.Run(new FormGudang());
                        break;
                    case "kasir":
                        Application.Run(new FormKasir());
                        break;
                }
            } else
            {
                Application.Run(new FormLogin());
            }
        }
    }
}
