namespace FoodXYZ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_user()
        {
            tbl_log = new HashSet<tbl_log>();
            tbl_transaksi = new HashSet<tbl_transaksi>();
        }

        [Key]
        public int id_user { get; set; }

        [Required]
        [StringLength(50)]
        public string tipe_user { get; set; }

        [Required]
        [StringLength(50)]
        public string nama { get; set; }

        [Required]
        [StringLength(150)]
        public string alamat { get; set; }

        [Required]
        [StringLength(50)]
        public string telpon { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_log> tbl_log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_transaksi> tbl_transaksi { get; set; }
    }
}
