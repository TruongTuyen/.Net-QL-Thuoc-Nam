using QLThuoc.Models.EF;
namespace QLThuoc.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CayThuoc_BaiThuoc
    {
        public int ID { get; set; }

        public int ID_CayThuoc { get; set; }

        public int ID_BaiThuoc { get; set; }

        [Column(TypeName = "text")]
        public string GhiChu { get; set; }
    }
}
