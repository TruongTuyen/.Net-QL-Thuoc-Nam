using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLThuoc.Models.EF;
using System.Collections;

namespace QLThuoc.Models.DB
{
    public class DbCayThuoc
    {
        public IEnumerable<CayThuoc> getList()
        {
            try
            {
                ModelDbContext db = new ModelDbContext();

                return db.CayThuocs.Where(b => b.TrangThai == 10);
            }
            catch
            {
                return null;
            }
        }

        public CayThuoc detail(int id)
        {
            try
            {
                ModelDbContext db = new ModelDbContext();
                return db.CayThuocs.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool add(CayThuoc caythuoc)
        {
            try
            {
                ModelDbContext db = new ModelDbContext();
                db.CayThuocs.Add(caythuoc);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool edit(CayThuoc caythuoc)
        {
            try
            {
                ModelDbContext db = new ModelDbContext();
                var old_data = db.CayThuocs.Find(caythuoc.ID);
                if(caythuoc.TenCayThuoc.Length >0)
                {
                    old_data.TenCayThuoc = caythuoc.TenCayThuoc;
                }
                
                old_data.AnhMinhHoa = caythuoc.AnhMinhHoa;
                old_data.CongDung = caythuoc.CongDung;
                old_data.ChiTiet = caythuoc.ChiTiet;
                old_data.GhiChu = caythuoc.GhiChu;
                old_data.TrangThai = caythuoc.TrangThai;

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
                var data = db.CayThuocs.Find(id);

                data.TrangThai = 1;
                
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
        public IEnumerable getData( int user_level, int user_id )
        {
            ModelDbContext db = new ModelDbContext();
            if ( user_level == 10)
            {
                return db.CayThuocs;
            }else
            {
                var data = db.CayThuocs.Where(b => b.ID_Nguoidung == user_id);
                return data;
            }
        }**/


        
    }
}