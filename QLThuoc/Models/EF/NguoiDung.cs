namespace QLThuoc.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNguoiDung { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        public byte Quyen { get; set; }

        [Column(TypeName = "text")]
        public string ThongTin { get; set; }
    }
}
