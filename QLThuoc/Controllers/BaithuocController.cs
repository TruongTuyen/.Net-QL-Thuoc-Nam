using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLThuoc.Models.DB;
using QLThuoc.Models.EF;

namespace QLThuoc.Controllers
{
    public class BaithuocController : Controller
    {
        // GET: Baithuoc
        public ActionResult Index()
        {
            DBBaithuoc db = new DBBaithuoc();
            var data = db.getList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Timkiem(FormCollection collections)
        {
            DBBaithuoc db = new DBBaithuoc();
            string str = collections["search_str"];
            var data = db.search(str);
            return View(data);
        }


        public ActionResult Danhsach()
        {
            DBBaithuoc db = new DBBaithuoc();
            var data = db.getList();
            return View(data);
        }


        // GET: Baithuoc/Details/5
        public ActionResult Details(int id)
        {
            DBBaithuoc db = new DBBaithuoc();
            var data = db.detail(id);

            //
            DbCaythuocBaithuoc cay_bai = new DbCaythuocBaithuoc();
            DbCayThuoc caythuoc_db = new DbCayThuoc();
            var lis_cay = cay_bai.cay_thuoc_theo_bai_thuoc(id);
            List<int> id_cay = new List<int>();

            foreach(var cay in lis_cay)
            {
                id_cay.Add(cay.ID_CayThuoc);
            }

            List<string> ten_cay = new List<string>();
            foreach( var id_cay_thuoc in id_cay)
            {
                var cay_thuoc = caythuoc_db.detail(id_cay_thuoc);
                ten_cay.Add(cay_thuoc.TenCayThuoc);
            }
            ViewBag.DsTenCay = ten_cay;


            //
            ViewBag.List_Cay = lis_cay;

            return View(data);
        }

        // GET: Baithuoc/Create
        public ActionResult Create()
        {

            /**
             using (var context = new ModelDbContext())
             {
                 var categories = context.CayThuocs.Select(c => new {
                     CategoryID = c.ID,
                     CategoryName = c.TenCayThuoc
                 }).ToList();
                 ViewBag.Categories = new MultiSelectList(categories, "CategoryID", "CategoryName");
                 return View();
             }**/
            danh_sach_cay_thuoc();
            return View();

        }

        // POST: Baithuoc/Create
        
         [HttpPost]
         public ActionResult Create(BaiThuoc baithuoc, int[] DanhSachCayThuoc)
         {
             try
             {
                // TODO: Add insert logic here
                danh_sach_cay_thuoc();
                
                 HttpPostedFileBase File = Request.Files["AnhMinhHoa"];
                  
                 string path = Server.MapPath("~/images/" + File.FileName);
                 string img_url = "images/" + File.FileName;
                 File.SaveAs(path);

                 baithuoc.AnhMinhHoa = img_url;

                 DBBaithuoc db = new DBBaithuoc();
                 DbCaythuocBaithuoc caythuoc_baithuoc = new DbCaythuocBaithuoc();
                 var ds_caythuoc = Request["DanhSachCayThuoc"];
                 
                 if (db.add(baithuoc))
                 {
                     foreach( int item in DanhSachCayThuoc)
                     {
                         caythuoc_baithuoc.addnew( item, baithuoc.ID);
                     }

                     return RedirectToAction("Index");
                     
                 }
                 else
                 {
                     return View(baithuoc);
                 }
                 
             }
             catch
             {
                 return View();
             }
         }
        


        // GET: Baithuoc/Edit/5
        public ActionResult Edit(int id)
        {
            danh_sach_cay_thuoc();
            DBBaithuoc db = new DBBaithuoc();
            DbCaythuocBaithuoc cay_bai = new DbCaythuocBaithuoc();
            var data = db.detail(id);

            ViewBag.Selected_caythuoc = cay_bai.cay_thuoc_theo_bai_thuoc(id);

            if (data != null)
            {
                return View(data);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Baithuoc/Edit/5
        [HttpPost]
        public ActionResult Edit(BaiThuoc baithuoc, int[] DanhSachCayThuoc)
        {
            danh_sach_cay_thuoc();
            DbCaythuocBaithuoc cay_bai = new DbCaythuocBaithuoc();
            DBBaithuoc bt = new DBBaithuoc();
            ViewBag.Selected_caythuoc = cay_bai.cay_thuoc_theo_bai_thuoc(baithuoc.ID);

            var old_data = bt.detail(baithuoc.ID);

            try
            {
                // TODO: Add update logic here
                HttpPostedFileBase File = Request.Files["AnhMinhHoa"];

                if(Request.Files["AnhMinhHoa"] != null) { 
                    string path = Server.MapPath("~/images/" + File.FileName);
                    string img_url = "images/" + File.FileName;
                    File.SaveAs(path);

                    baithuoc.AnhMinhHoa = img_url;
                }else
                {
                    baithuoc.AnhMinhHoa = old_data.AnhMinhHoa;
                }
                DBBaithuoc db = new DBBaithuoc();
                DbCaythuocBaithuoc caythuoc_baithuoc = new DbCaythuocBaithuoc();
                

                if (db.edit(baithuoc))
                {
                    caythuoc_baithuoc.delete(baithuoc.ID);
                   

                    foreach (int item in DanhSachCayThuoc)
                    {
                        caythuoc_baithuoc.addnew(item, baithuoc.ID);
                    }

                    return RedirectToAction("Index");

                }
                else
                {
                    return View(baithuoc);
                }
               
            }
            catch
            {
                return View(baithuoc);
            }
        }

        // GET: Baithuoc/Delete/5
        public ActionResult Delete(int id)
        {
            DBBaithuoc db = new DBBaithuoc();
            var data = db.detail(id);

            if (data != null)
            {
                return View(data);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Baithuoc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            DBBaithuoc db = new DBBaithuoc();
            var data = db.detail(id);
            try
            {
                // TODO: Add delete logic here

                if (db.delete(id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Delete_Message = "Không thể xóa dữ liệu";
                    return View(data);
                }


            }
            catch
            {
                ViewBag.Delete_Message = "Không thể xóa dữ liệu";
                return View(data);
            }
        }
        /**
        public void danh_sach_cay_thuoc(int? selectedID = null)
        {
            var context = new DbCayThuoc();
            ViewBag.ID_Caythuoc = new SelectList(context.getList(), "ID", "TenCayThuoc", selectedID);
        }**/

        public void danh_sach_cay_thuoc()
        {
            ModelDbContext context = new ModelDbContext();
            ViewBag.ID_Caythuoc = context.CayThuocs.Where( b=> b.TrangThai == 10);
        }

    }
}
