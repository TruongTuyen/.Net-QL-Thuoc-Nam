namespace QLThuoc.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CayThuoc")]
    public partial class CayThuoc
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name ="Tên cây thuốc")]
        public string TenCayThuoc { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh minh họa")]
        public string AnhMinhHoa { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Công dụng")]
        public string CongDung { get; set; }

        [Display(Name = "Chi tiết")]
        [Column(TypeName = "text")]
        [Required]
        public string ChiTiet { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        [Display(Name = "Trạng thái")]
        public byte TrangThai { get; set; }

        
    }
}
