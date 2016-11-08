namespace QLThuoc.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<BaiThuoc> BaiThuocs { get; set; }
        public virtual DbSet<CayThuoc> CayThuocs { get; set; }
        public virtual DbSet<CayThuoc_BaiThuoc> CayThuoc_BaiThuoc{ get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiThuoc>()
                .Property(e => e.TenBaiThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<BaiThuoc>()
                .Property(e => e.AnhMinhHoa)
                .IsUnicode(false);

            modelBuilder.Entity<BaiThuoc>()
                .Property(e => e.CongDung)
                .IsUnicode(false);

            modelBuilder.Entity<BaiThuoc>()
                .Property(e => e.ThanhPhan)
                .IsUnicode(false);

            modelBuilder.Entity<BaiThuoc>()
                .Property(e => e.GhiChu)
                .IsUnicode(false);

            modelBuilder.Entity<CayThuoc>()
                .Property(e => e.TenCayThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<CayThuoc>()
                .Property(e => e.AnhMinhHoa)
                .IsUnicode(false);

            modelBuilder.Entity<CayThuoc>()
                .Property(e => e.CongDung)
                .IsUnicode(false);

            modelBuilder.Entity<CayThuoc>()
                .Property(e => e.ChiTiet)
                .IsUnicode(false);

            modelBuilder.Entity<CayThuoc>()
                .Property(e => e.GhiChu)
                .IsUnicode(false);

            modelBuilder.Entity<CayThuoc_BaiThuoc>()
                .Property(e => e.GhiChu)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TenNguoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.ThongTin)
                .IsUnicode(false);
        }
    }
}
