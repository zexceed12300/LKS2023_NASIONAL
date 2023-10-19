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
    public partial class FormKelolaLaporan : Form
    {
        FoodxyzDbContext context = new FoodxyzDbContext();

        List<tbl_transaksi> transaksi;

        public FormKelolaLaporan()
        {
            InitializeComponent();
            filterTransaksi();
        }

        private void filterTransaksi()
        {
            transaksi = context.tbl_transaksi.Where(x => x.tgl_transaksi >= dtpFilterFrom.Value && x.tgl_transaksi <= dtpFilterTo.Value).ToList();
            var datagrid = from a in transaksi
                           join b in context.tbl_user on a.id_user equals b.id_user
                           select new { a.id_transaksi, a.tgl_transaksi, a.total_bayar, id_user = b.nama };
            dgvTransaksi.DataSource = datagrid;
        }

        private void FormKelolaLaporan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'foodxyzDataSet.tbl_transaksi' table. You can move, or remove it, as needed.
            this.tbl_transaksiTableAdapter.Fill(this.foodxyzDataSet.tbl_transaksi);

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            filterTransaksi();
        }
    }
}
