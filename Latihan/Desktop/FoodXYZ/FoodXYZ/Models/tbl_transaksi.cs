namespace FoodXYZ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_transaksi
    {
        [Key]
        public int id_transaksi { get; set; }

        [Required]
        [StringLength(50)]
        public string no_transaksi { get; set; }

        [Column(TypeName = "date")]
        public DateTime tgl_transaksi { get; set; }

        public long total_bayar { get; set; }

        public int id_user { get; set; }

        public int id_barang { get; set; }

        public virtual tbl_barang tbl_barang { get; set; }

        public virtual tbl_user tbl_user { get; set; }
    }
}
