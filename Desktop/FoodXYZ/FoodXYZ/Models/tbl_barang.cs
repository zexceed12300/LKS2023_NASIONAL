namespace FoodXYZ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_barang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_barang()
        {
            tbl_transaksi = new HashSet<tbl_transaksi>();
        }

        [Key]
        public int id_barang { get; set; }

        [Required]
        [StringLength(50)]
        public string kode_barang { get; set; }

        [Required]
        [StringLength(50)]
        public string nama_barang { get; set; }

        [Column(TypeName = "date")]
        public DateTime expired_date { get; set; }

        public long jumlah_barang { get; set; }

        [Required]
        [StringLength(50)]
        public string satuan { get; set; }

        public long harga_satuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_transaksi> tbl_transaksi { get; set; }
    }
}
