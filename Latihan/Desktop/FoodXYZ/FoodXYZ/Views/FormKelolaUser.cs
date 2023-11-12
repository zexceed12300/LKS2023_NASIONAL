using FoodXYZ.Models;
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
    public partial class FormKelolaUser : Form
    {
        FoodxyzDbContext context = new FoodxyzDbContext();

        List<tbl_user> users;

        private void queryUsers(string search)
        {
            users = context.tbl_user.Where(x => x.nama.Contains(search)).ToList();
            dgvUsers.DataSource = users;
        }

        public FormKelolaUser()
        {
            InitializeComponent();
            queryUsers(tbSearch.Text);
        }

        private void FormKelolaUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodxyzDataSet.tbl_user' table. You can move, or remove it, as needed.
            //this.tbl_userTableAdapter.Fill(this.foodxyzDataSet.tbl_user);

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbTipeUser.Text == "" || tbNama.Text == "" || tbTelpon.Text == "" || tbAlamat.Text == "" || tbUsername.Text == "" || tbPassword.Text == "")
                {
                    MessageBox.Show("Please fill form!");
                } else
                {
                    context.tbl_user.Add(new tbl_user
                    {
                        tipe_user = cbTipeUser.Text,
                        nama = tbNama.Text,
                        telpon = tbTelpon.Text,
                        alamat = tbAlamat.Text,
                        username = tbUsername.Text,
                        password = tbPassword.Text,
                    });
                    context.SaveChanges();
                    MessageBox.Show("User created!");
                }


            } catch (Exception ex)
            {
                MessageBox.Show("Failed to create user, something was wrong!");
            }
            queryUsers(tbSearch.Text);
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbTipeUser.Text = dgvUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbNama.Text = dgvUsers.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbAlamat.Text = dgvUsers.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbTelpon.Text = dgvUsers.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbTipeUser.Text == "" || tbNama.Text == "" || tbTelpon.Text == "" || tbAlamat.Text == "" || tbUsername.Text == "" || tbPassword.Text == "")
                {
                    MessageBox.Show("Please fill form!");
                }
                else
                {
                    var record = context.tbl_user.Find(dgvUsers.SelectedCells[0].OwningRow.Cells[0].Value);
                    record.tipe_user = cbTipeUser.Text;
                    record.nama = tbNama.Text;
                    record.telpon = tbTelpon.Text;
                    record.alamat = tbAlamat.Text;
                    record.username = tbUsername.Text;
                    record.password = tbPassword.Text;
                    context.SaveChanges();
                }
                MessageBox.Show("User edited!");
            } catch (Exception ex)
            {
                MessageBox.Show("Failed to create user, something was wrong!");
            }
            queryUsers(tbSearch.Text);
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                var record = context.tbl_user.Find(dgvUsers.SelectedCells[0].OwningRow.Cells[0].Value);
                context.tbl_user.Remove(record);
                context.SaveChanges();
                MessageBox.Show($"User {record.nama} deleted!");
            } catch (Exception ex)
            {
                MessageBox.Show("Failed to create user, something was wrong!");
            }
            queryUsers(tbSearch.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            queryUsers(tbSearch.Text);
        }
    }
}
