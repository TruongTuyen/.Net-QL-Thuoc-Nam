using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLThuoc.Models.DB;
using QLThuoc.Models.EF;


namespace QLThuoc.Controllers
{
    public class CaythuocController : Controller
    {
        // GET: Caythuoc
        public ActionResult Index()
        {
            DbCayThuoc db = new DbCayThuoc();
            var data = db.getList();
            return View(data);
        }

        public ActionResult Danhsach()
        {
            DbCayThuoc db = new DbCayThuoc();
            var data = db.getList();
            return View(data);
        }

        // GET: Caythuoc/Details/5
        public ActionResult Details(int id)
        {
            DbCayThuoc db = new DbCayThuoc();
            var data = db.detail(id);
            return View(data);
        }

        // GET: Caythuoc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Caythuoc/Create
        [HttpPost]
        public ActionResult Create( CayThuoc caythuoc ) //FormCollection collection
        {
            DbCayThuoc db = new DbCayThuoc();
            //if (new System.IO.FileInfo("AnhMinhHoa").Length != 0)

            try
            {
                HttpPostedFileBase File = Request.Files["AnhMinhHoa"];
                string path = Server.MapPath("~/images/" + File.FileName);
                string img_url = "images/" + File.FileName;
                File.SaveAs(path);
                caythuoc.AnhMinhHoa = img_url;

                if (db.add(caythuoc))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Caythuoc_add_message = "Không thể thêm dữ liệu 10";
                    return View();
                }

               
            }
            catch
            {
                ViewBag.Caythuoc_add_message = "Không thể thêm dữ liệu";
                return View();
            }

            
        }

        // GET: Caythuoc/Edit/5
        public ActionResult Edit(int id)
        {
            DbCayThuoc db = new DbCayThuoc();
            var data = db.detail(id);

            if( data != null)
            {
                return View(data);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        // POST: Caythuoc/Edit/5
        [HttpPost]
        public ActionResult Edit(CayThuoc caythuoc)
        {

            DbCayThuoc db = new DbCayThuoc();
            var old_data = db.detail(caythuoc.ID);
            //if (new System.IO.FileInfo("AnhMinhHoa").Length != 0)

            try
            {
                if(Request.Files["AnhMinhHoa"] != null)
                {
                    HttpPostedFileBase File = Request.Files["AnhMinhHoa"];
                    string path = Server.MapPath("~/images/" + File.FileName);
                    string img_url = "images/" + File.FileName;
                    File.SaveAs(path);
                    caythuoc.AnhMinhHoa = img_url;
                }
                else
                {
                    caythuoc.AnhMinhHoa = old_data.AnhMinhHoa;
                }
                

                if (db.edit(caythuoc))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Caythuoc_add_message = "Không thể sửa dữ liệu 10";
                    return View();
                }


            }
            catch
            {
                ViewBag.Caythuoc_add_message = "Không thể sửa dữ liệu";
                return View();
            }
        }

        // GET: Caythuoc/Delete/5
        public ActionResult Delete(int id)
        {
            DbCayThuoc db = new DbCayThuoc();
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

        // POST: Caythuoc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            DbCayThuoc db = new DbCayThuoc();
            var data = db.detail(id);
            try
            {
                // TODO: Add delete logic here
                
                if (db.delete(id))
                {
                    return RedirectToAction("Index");
                }else
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
    }
}
