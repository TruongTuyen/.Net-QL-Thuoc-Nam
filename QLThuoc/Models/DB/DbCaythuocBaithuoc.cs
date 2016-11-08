using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLThuoc.Models.EF;

namespace QLThuoc.Models.DB
{
    public class DbCaythuocBaithuoc
    {
        public bool addnew( int id_caythuoc, int id_baithuoc )
        {
            ModelDbContext db = new ModelDbContext();
            try
            {
                CayThuoc_BaiThuoc caythuoc_baithuoc = new CayThuoc_BaiThuoc();
                caythuoc_baithuoc.ID_BaiThuoc = id_baithuoc;
                caythuoc_baithuoc.ID_CayThuoc = id_caythuoc;
                db.CayThuoc_BaiThuoc.Add(caythuoc_baithuoc);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool delete(int id_baithuoc)
        {
            ModelDbContext db = new ModelDbContext();
            try
            {
                var list_lk = db.CayThuoc_BaiThuoc.Where(b => b.ID_BaiThuoc == id_baithuoc);
                foreach( var item in list_lk)
                {
                    //var data = db.CayThuoc_BaiThuoc.Find(item.ID);
                    //db.CayThuoc_BaiThuoc.Remove(data);
                    db.CayThuoc_BaiThuoc.Remove(item);
                   
                }
                db.SaveChanges();
                return true;
            }catch
            {
                return false;
            }
        }


        public IEnumerable<CayThuoc_BaiThuoc> cay_thuoc_theo_bai_thuoc( int id_bai_thuoc)
        {
            ModelDbContext db = new ModelDbContext();
            try
            {
                var data = db.CayThuoc_BaiThuoc.Where(b => b.ID_BaiThuoc == id_bai_thuoc);
                return data;
            }
            catch
            {
                return null;
            }
        }



    }
}