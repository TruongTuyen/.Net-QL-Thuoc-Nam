using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLThuoc.Models.EF;

namespace QLThuoc.Models.DB
{
    public class DBBaithuoc
    {
        public IEnumerable<BaiThuoc> getList()
        {
            try
            {
                ModelDbContext db = new ModelDbContext();

                return db.BaiThuocs.Where(b => b.TrangThai == 10);
            }
            catch
            {
                return null;
            }
        }

        public BaiThuoc detail(int id)
        {
            try
            {
                ModelDbContext db = new ModelDbContext();
                return db.BaiThuocs.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool add(BaiThuoc baithuoc)
        {
            try
            {
                ModelDbContext db = new ModelDbContext();
                db.BaiThuocs.Add(baithuoc);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool edit(BaiThuoc baithuoc)
        {
            try
            {
                ModelDbContext db = new ModelDbContext();
                var old_data = db.BaiThuocs.Find(baithuoc.ID);
                
                old_data.TenBaiThuoc = baithuoc.TenBaiThuoc;
                
                old_data.AnhMinhHoa = baithuoc.AnhMinhHoa;
                old_data.CongDung = baithuoc.CongDung;
                old_data.ThanhPhan = baithuoc.ThanhPhan;
                old_data.GhiChu = baithuoc.GhiChu;
                old_data.TrangThai = baithuoc.TrangThai;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool delete(int id)
        {
            try
            {
                ModelDbContext db = new ModelDbContext();
                var data = db.BaiThuocs.Find(id);
                data.TrangThai = 1; //1 hidden, 10: show
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<BaiThuoc> search( string str)
        {
            try
            {
                ModelDbContext db = new ModelDbContext();
                var data = db.BaiThuocs.Where( b=> b.TenBaiThuoc.Contains(str) ).Where( b=>b.TrangThai == 10);
                return data;
            }
            catch
            {
                return null;
            }
        }

    }
}