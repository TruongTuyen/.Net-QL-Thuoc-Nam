using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLThuoc.Models.EF;

namespace QLThuoc.Models.DB
{
    public class DBNguoiDung
    {
        public bool check_login( string username, string password )
        {
            using (var context = new ModelDbContext() )
            {
                //var user = context.NguoiDungs.Where(b => b.TenNguoiDung == "ADO.NET Blog",  b => b.MatKhau == "").FirstOrDefault();
                var user = context.NguoiDungs.Where(b => b.TenNguoiDung == username).Where(b => b.MatKhau == password).FirstOrDefault();
                if( user.TenNguoiDung != "" )
                {
                    return true;
                }else
                {
                    return false;
                }
                
            }
            //return false;
        }

        public NguoiDung detail( int id)
        {
            try
            {
                ModelDbContext db = new ModelDbContext();

                var user_detail = db.NguoiDungs.Find(id);
                return user_detail;
            }
            catch
            {
                return null;
            }
        }


        public NguoiDung getInfoByUsername(string username)
        {
            try
            {
                using (var context = new ModelDbContext())
                {
                    //var user = context.NguoiDungs.Where(b => b.TenNguoiDung == "ADO.NET Blog",  b => b.MatKhau == "").FirstOrDefault();
                    var user = context.NguoiDungs.Where(b => b.TenNguoiDung == username).FirstOrDefault();
                    return user;
                }
            }
            catch
            {
                return null;
            }
        }



        public IEnumerable<NguoiDung> getList()
        {
            try
            {
                ModelDbContext db = new ModelDbContext();

                return db.NguoiDungs;
            }
            catch
            {
                return null;
            }
        }

        
        public bool add(NguoiDung nd)
        {
            try
            {
                ModelDbContext db = new ModelDbContext();
                db.NguoiDungs.Add(nd);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool edit(NguoiDung nd)
        {
            try
            {
                ModelDbContext db = new ModelDbContext();
                var old_data = db.NguoiDungs.Find(nd.ID);

                old_data.TenNguoiDung = nd.TenNguoiDung;

                old_data.MatKhau = nd.MatKhau;
                old_data.Quyen = nd.Quyen;
                old_data.ThongTin = nd.ThongTin;

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
                var data = db.NguoiDungs.Find(id);
                db.NguoiDungs.Remove(data);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}