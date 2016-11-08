using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLThuoc.Models.DB;
using QLThuoc.Models.EF;

namespace QLThuoc.Controllers
{
    public class NguoidungController : Controller
    {
        // GET: Nguoidung
        public ActionResult Index()
        {
            DBNguoiDung db = new DBNguoiDung();
            var data = db.getList();
            return View(data);
        }

        // GET: Nguoidung/Details/5
        public ActionResult Details(int id)
        {
            DBNguoiDung db = new DBNguoiDung();
            var data = db.detail(id);
            return View(data);
        }

        // GET: Nguoidung/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nguoidung/Create
        [HttpPost]
        public ActionResult Create(NguoiDung nd)
        {
            DBNguoiDung db = new DBNguoiDung();
            try
            {
                // TODO: Add insert logic here
                if(db.add(nd))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(nd);
                }
               
            }
            catch
            {
                return View();
            }
        }

        // GET: Nguoidung/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Nguoidung/Login
        [HttpPost]
        public ActionResult Login(NguoiDung nguoidung)
        {
            ViewBag.Login_Message = "Sai tên đăng nhập hoặc mật khẩu, vui lòng thử lại.";
            try
            {
                DBNguoiDung db_user = new DBNguoiDung();
                string username = nguoidung.TenNguoiDung;
                string user_pw = nguoidung.MatKhau;
                var check_login = db_user.check_login(username, user_pw);
                

                if (check_login)
                {
                    //Set Session
                    var user_info = db_user.getInfoByUsername(username);

                    if( user_info.TenNguoiDung != "") {
                        Session["username"] = user_info.TenNguoiDung;
                        Session["user_logged_in"] = true;
                        Session["user_logged_level"] = user_info.Quyen;

                        return RedirectToAction("Index", "Caythuoc");
                    }
                    else{
                        ViewBag.Login_Message = "Người dùng không tồn tại. Vui lòng thử lại.";
                        return View(nguoidung);
                    }
                    
                }
                else
                {
                    //Wrong some things
                    ViewBag.Login_Message = "Check login.";
                    return View(nguoidung);
                }

                // TODO: Add insert logic here
                
            }
            catch
            {
                return View(nguoidung);
            }
        }

        // GET: Nguoidung/Logout
        public ActionResult Logout()
        {
            Session.Remove("username");
            Session.Remove("user_logged_in");
            Session.Remove("user_logged_level");
            
            return RedirectToAction("Login");
           
        }

        // GET: Nguoidung/Edit/5
        public ActionResult Edit(int id)
        {
            DBNguoiDung db = new DBNguoiDung();
            var data = db.detail(id);
            return View(data);
        }

        // POST: Nguoidung/Edit/5
        [HttpPost]
        public ActionResult Edit(NguoiDung nd)
        {
            DBNguoiDung db = new DBNguoiDung();
            try
            {
                // TODO: Add update logic here
                if (db.edit(nd))
                {
                    return RedirectToAction("Index");
                }else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Nguoidung/Delete/5
        public ActionResult Delete(int id)
        {
            DBNguoiDung db = new DBNguoiDung();
            var data = db.detail(id);
            return View(data);
        }

        // POST: Nguoidung/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            DBNguoiDung db = new DBNguoiDung();
            try
            {
                // TODO: Add delete logic here
                if(db.delete(id))
                {
                    return RedirectToAction("Index");
                }else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }
    }
}
