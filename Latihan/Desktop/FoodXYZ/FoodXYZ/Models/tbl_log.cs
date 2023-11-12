namespace FoodXYZ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_log
    {
        [Key]
        public int id_log { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] waktu { get; set; }

        [Required]
        [StringLength(50)]
        public string aktivitas { get; set; }

        public int id_user { get; set; }

        public virtual tbl_user tbl_user { get; set; }
    }
}
