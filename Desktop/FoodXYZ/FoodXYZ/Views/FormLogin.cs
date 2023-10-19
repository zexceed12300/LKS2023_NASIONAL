using FoodXYZ.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodXYZ.Views
{
    public partial class FormLogin : Form
    {
        AuthController authController = new AuthController();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool login = authController.login(tbUsername.Text, tbPassword.Text);
            if (login)
            {
                switch(authController.getUserLoggedIn().tipe_user) {
                    case "admin":
                        this.Hide();
                        (new FormAdmin()).Show();
                        break;
                    case "gudang":
                        this.Hide();
                        (new FormGudang()).Show();
                        break;
                    case "kasir":
                        this.Hide();
                        (new FormKasir()).Show();
                        break;
                }
            }
        }
    }
}
