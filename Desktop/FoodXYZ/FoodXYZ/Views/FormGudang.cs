using FoodXYZ.Controllers;
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
    public partial class FormGudang : Form
    {
        AuthController authController = new AuthController();

        FoodxyzDbContext context = new FoodxyzDbContext();

        List<tbl_barang> barangs;

        public FormGudang()
        {
            InitializeComponent();
        }

        private void queryBarang(string search)
        {
            barangs = context.tbl_barang.Where(e => e.nama_barang.Contains(tbSearch.Text)).ToList();
            dgvBarangs.DataSource = barangs;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbKodeBarang.Text == "" || tbNamaBarang.Text == "" || dtpExpiredData.Text == "" || tbJumlahBarang.Text == "" || cbSatuan.Text == "" || tbHargaPerSatuan.Text == "")
                {
                    MessageBox.Show("Please fill form!");
                }
                else
                {
                    context.tbl_barang.Add(new tbl_barang
                    {
                        kode_barang = tbKodeBarang.Text,
                        nama_barang = tbNamaBarang.Text,
                        expired_date = dtpExpiredData.Value,
                        jumlah_barang = Convert.ToInt32(tbJumlahBarang.Text),
                        satuan = cbSatuan.Text,
                        harga_satuan = Convert.ToInt32(tbHargaPerSatuan.Text),
                    });
                    context.SaveChanges();
                    MessageBox.Show("Barang created!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create user, something was wrong!");
            }
            queryBarang(tbSearch.Text);
        }

        private void FormGudang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodxyzDataSet1.tbl_barang' table. You can move, or remove it, as needed.
            this.tbl_barangTableAdapter.Fill(this.foodxyzDataSet1.tbl_barang);

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            authController.logout();
            this.Hide();
            (new FormLogin()).Show();
        }

        private void dgvBarangs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbKodeBarang.Text = dgvBarangs.SelectedCells[0].OwningRow.Cells[1].Value.ToString();
            tbNamaBarang.Text = dgvBarangs.SelectedCells[0].OwningRow.Cells[2].Value.ToString();
            dtpExpiredData.Text = dgvBarangs.SelectedCells[0].OwningRow.Cells[3].Value.ToString();
            tbJumlahBarang.Text = dgvBarangs.SelectedCells[0].OwningRow.Cells[4].Value.ToString();
            cbSatuan.Text = dgvBarangs.SelectedCells[0].OwningRow.Cells[5].Value.ToString();
            tbHargaPerSatuan.Text = dgvBarangs.SelectedCells[0].OwningRow.Cells[6].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbKodeBarang.Text == "" || tbNamaBarang.Text == "" || dtpExpiredData.Text == "" || tbJumlahBarang.Text == "" || cbSatuan.Text == "" || tbHargaPerSatuan.Text == "")
                {
                    MessageBox.Show("Please fill form!");
                } 
                else
                {
                    var barang = context.tbl_barang.Find(dgvBarangs.SelectedCells[0].OwningRow.Cells[0].Value);
                    barang.kode_barang = tbKodeBarang.Text;
                    barang.nama_barang = tbNamaBarang.Text;
                    barang.expired_date = dtpExpiredData.Value;
                    barang.jumlah_barang = Convert.ToInt32(tbJumlahBarang.Text);
                    barang.satuan = cbSatuan.Text;
                    barang.harga_satuan = Convert.ToInt32(tbHargaPerSatuan.Text);
                    context.SaveChanges();
                    MessageBox.Show("Barang edited!");
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Failed to create user, something was wrong!");
            }
            queryBarang(tbSearch.Text);
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                var barang = context.tbl_barang.Find(dgvBarangs.SelectedCells[0].OwningRow.Cells[0].Value);
                context.tbl_barang.Remove(barang);
                context.SaveChanges();
                MessageBox.Show("Barang removed!");
            } catch (Exception ex)
            {
                MessageBox.Show("Failed to create user, something was wrong!");
            }
            queryBarang(tbSearch.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            queryBarang(tbSearch.Text);
        }
    }
}
