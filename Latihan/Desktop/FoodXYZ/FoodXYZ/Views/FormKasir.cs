using FoodXYZ.Controllers;
using FoodXYZ.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FoodXYZ.Views
{
    public partial class FormKasir : Form
    {
        FoodxyzDbContext context = new FoodxyzDbContext();

        AuthController authController = new AuthController();
        
        private List<keranjang> keranjangs = new List<keranjang>();

        public FormKasir()
        {
            InitializeComponent();
        }

        private void queryKeranjang()
        {
            dgvKeranjang.DataSource = null;
            dgvKeranjang.DataSource = keranjangs;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            authController.logout();
            this.Hide();
            (new FormLogin()).Show();
        }

        private void FormKasir_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodxyzDataSet.tbl_transaksi' table. You can move, or remove it, as needed.
            this.tbl_transaksiTableAdapter.Fill(this.foodxyzDataSet.tbl_transaksi);

            var menu = context.tbl_barang.ToList();
            foreach (var item in menu)
            {
                cbPilihMenu.Items.Add(item.nama_barang);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {

            var menu = context.tbl_barang.FirstOrDefault(x => x.nama_barang == cbPilihMenu.Text);

            keranjangs.Add(new keranjang
            {
                id_transaksi = keranjangs.Count() + 1,
                kode_barang = cbPilihMenu.Text.ToString(),
                nama_barang = menu.nama_barang.ToString(),
                harga_satuan = Convert.ToInt32(menu.harga_satuan),
                kuantitas = Convert.ToInt32(tbKuantitas.Text),
                subtotal = Convert.ToInt32(menu.harga_satuan) * Convert.ToInt32(tbKuantitas.Text),
            });

            queryKeranjang();
        }

        private void cbPilihMenu_TextChanged(object sender, EventArgs e)
        {
            var menu = context.tbl_barang.FirstOrDefault(x => x.nama_barang == cbPilihMenu.Text);
            tbHargaSatuan.Text = menu.harga_satuan.ToString();
        }

        private void tbKuantitas_TextChanged(object sender, EventArgs e)
        {
            tbTotalHarga.Text = (Convert.ToInt32(tbHargaSatuan.Text) * Convert.ToInt32(tbKuantitas.Text != "" ? tbKuantitas.Text : "0")).ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            keranjangs = new List<keranjang>();
            queryKeranjang();
        }
    }
}
