using HovLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HovLibrary.Controllers
{
    class AuthController
    {
        HovLibraryDb context = new HovLibraryDb();

        private bool verifyPassword(string password, string hash)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] stringBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(stringBytes);
                string hashedText = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                Console.WriteLine(hashedText);

                if (hash == hashedText)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        public bool login(string email, string password)
        {
            var employee = context.Employees.FirstOrDefault(e => e.email == email);
            if (employee != null) 
            { 
                if (verifyPassword(password, employee.password))
                {
                    Properties.Settings.Default.userId = employee.id;
                    Properties.Settings.Default.isLoggedIn = true;
                    Properties.Settings.Default.Save();
                    return true;
                } else
                {
                    return false;
                }
            }
            return false;
        }

        public bool isLoggedIn()
        {
            return Properties.Settings.Default.isLoggedIn;
        }

        public void logout()
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
        }
    }
}
