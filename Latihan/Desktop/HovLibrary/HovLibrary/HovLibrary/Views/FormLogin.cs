using HovLibrary.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary.Views
{
    public partial class FormLogin : Form
    {
        AuthController auth = new AuthController();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool login = auth.login(tbEmail.Text, tbPassword.Text);
            if (login)
            {
                this.Hide();
                (new FormMain()).Show();
            } else
            {
                MessageBox.Show("Username or password incorrect!");
            }
        }
    }
}
