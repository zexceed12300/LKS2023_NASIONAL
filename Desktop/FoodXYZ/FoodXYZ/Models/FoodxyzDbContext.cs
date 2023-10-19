using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FoodXYZ.Models
{
    public partial class FoodxyzDbContext : DbContext
    {
        public FoodxyzDbContext()
            : base("name=FoodxyzDbContext")
        {
        }

        public virtual DbSet<tbl_barang> tbl_barang { get; set; }
        public virtual DbSet<tbl_log> tbl_log { get; set; }
        public virtual DbSet<tbl_transaksi> tbl_transaksi { get; set; }
        public virtual DbSet<tbl_user> tbl_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_barang>()
                .HasMany(e => e.tbl_transaksi)
                .WithRequired(e => e.tbl_barang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_log>()
                .Property(e => e.waktu)
                .IsFixedLength();

            modelBuilder.Entity<tbl_user>()
                .HasMany(e => e.tbl_log)
                .WithRequired(e => e.tbl_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_user>()
                .HasMany(e => e.tbl_transaksi)
                .WithRequired(e => e.tbl_user)
                .WillCascadeOnDelete(false);
        }
    }
}
