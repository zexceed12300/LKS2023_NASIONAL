using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodXYZ.Models
{
    class keranjang
    {
        public int id_transaksi { get; set; }
        public string kode_barang { get; set; }
        public string nama_barang { get; set; }
        public int harga_satuan { get; set; }
        public int kuantitas { get; set; }
        public int subtotal { get; set; }
    }
}
