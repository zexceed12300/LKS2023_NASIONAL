using FoodXYZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodXYZ.Controllers
{
    class AuthController
    {
        FoodxyzDbContext context = new FoodxyzDbContext();
        public bool login(string username, string password)
        {
            try
            {
                var user = context.tbl_user.FirstOrDefault(e => e.username == username && e.password == password);
                if (user != null)
                {
                    Properties.Settings.Default.userId = user.id_user;
                    Properties.Settings.Default.role = user.tipe_user;
                    Properties.Settings.Default.isLoggedIn = true;
                    Properties.Settings.Default.Save();
                    return true;
                } else
                {
                    MessageBox.Show("Username or password invalid!");
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Something's wrong!");
            }
            return false;
        }

        public void logout()
        {
            Properties.Settings.Default.userId = 0;
            Properties.Settings.Default.role = "";
            Properties.Settings.Default.isLoggedIn = false;
            Properties.Settings.Default.Save();
            Console.WriteLine(Properties.Settings.Default.isLoggedIn);
        }

        public bool isLoggedIn()
        {
            return Properties.Settings.Default.isLoggedIn;
        }

        public tbl_user getUserLoggedIn()
        {
            var user = context.tbl_user.Find(Properties.Settings.Default.userId);

            return new tbl_user
            {
                id_user = user.id_user,
                tipe_user = user.tipe_user,
                nama = user.nama,
                alamat = user.alamat,
                telpon = user.telpon,
                username = null,
                password = null,
            };
        }
    }
}
