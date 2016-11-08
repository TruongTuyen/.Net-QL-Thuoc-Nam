namespace QLThuoc.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiThuoc")]
    public partial class BaiThuoc
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name ="Tên bài thuốc")]
        public string TenBaiThuoc { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh minh họa")]
        public string AnhMinhHoa { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Công dụng")]
        public string CongDung { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Thành phần")]
        public string ThanhPhan { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        public byte TrangThai { get; set; }
    }
}
