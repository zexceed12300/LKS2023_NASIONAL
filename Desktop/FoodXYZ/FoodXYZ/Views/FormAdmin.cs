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
    public partial class FormAdmin : Form
    {
        AuthController authController = new AuthController();
        public FormAdmin()
        {
            InitializeComponent();

            this.panelContainer.Controls.Clear();
            FormKelolaUser form = new FormKelolaUser()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            this.panelContainer.Controls.Add(form);
            form.Show();
        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            this.panelContainer.Controls.Clear();
            FormKelolaUser form = new FormKelolaUser()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            this.panelContainer.Controls.Add(form);
            form.Show();
        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
            this.panelContainer.Controls.Clear();
            FormKelolaLaporan form = new FormKelolaLaporan()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
            };
            this.panelContainer.Controls.Add(form);
            form.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            authController.logout();
            this.Hide();
            (new FormLogin()).Show();
        }
    }
}
