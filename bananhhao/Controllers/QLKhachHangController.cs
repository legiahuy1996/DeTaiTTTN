using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bananhhao.Models;
namespace bananhhao.Controllers
{
    public class QLKhachHangController : Controller
    {

        // GET: QLKhachHang
        private DataClasses1DataContext db;
        public QLKhachHangController()
        {
            db = new DataClasses1DataContext();
        }
        public ActionResult Index()
        {
            List<khachhang> lst = db.khachhangs.ToList();

            return View(lst);
        }
        [HttpGet]
        public ActionResult Insert()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Insert(khachhang kh)
        {
            
            if(db.khachhangs.SingleOrDefault(x=>x.makh == kh.makh)!=null)
            {
                Session["ThongBao"] = "Mã khách hàng đã tồn tại!";
                return View("Insert");
            }
            else if(db.khachhangs.SingleOrDefault(x=>x.makh!=kh.makh && x.cmnd == kh.cmnd)!=null)
            {
                Session["ThongBao"] = "Số chứng minh đã tồn tại!";
                return View("Insert");
            }
            else if (kh.makh.Length < 13 || kh.tenkh == null || kh.diachi == null || kh.dt == null || kh.cmnd == null && kh.cmnd.Length < 9)
            {
                Session["ThongBao"] = "Có lỗi khi thêm khách hàng";
                return View("Insert");
            }
            else 
            {
                try
                {
                    db.khachhangs.InsertOnSubmit(kh);
                    db.SubmitChanges();
                    Session["ThongBao"] = "001";
                }
                catch (Exception e)
                {
                    Session["ThongBao"] = e.Message;
                    return View("Insert");
                }

            }
           
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            khachhang kh = db.khachhangs.SingleOrDefault(x => x.makh == id);
            return View(kh);
        }
        [HttpPost]
        public ActionResult Edit(string makh, string tenkh, string diachi, string dienthoai, string cmnd)
        {
            khachhang save = new khachhang { makh = makh, tenkh = tenkh, diachi = diachi, dt = dienthoai, cmnd = cmnd };
            khachhang check = db.khachhangs.SingleOrDefault(x => x.cmnd == cmnd && x.makh != makh);
            try
            {
               
                if (makh.Length < 13 || tenkh == null || diachi == null || dienthoai == null || cmnd.Length == 0 && cmnd.Length != 9)
                {
                    Session["ThongBao"] = "Có lỗi khi sửa khách hàng";
                    return RedirectToAction("Edit", new { id = makh });
                }
                else if(check!=null)
                {
                    Session["ThongBao"] = "Số chứng minh đã tồn tại!";
                    return RedirectToAction("Edit", new { id = makh });
                }
                khachhang kh = db.khachhangs.SingleOrDefault(x => x.makh == makh);
                
                kh.tenkh = tenkh;
                kh.diachi = diachi;
                kh.dt = dienthoai;
                kh.cmnd = cmnd;

                db.SubmitChanges();
                Session["ThongBao"] = "002";
            }
            catch (Exception e)
            {
                Session["ThongBao"] = e.Message;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(string makh)
        {
            try
            {
                khachhang kh = db.khachhangs.SingleOrDefault(x => x.makh == makh);

                db.khachhangs.DeleteOnSubmit(kh);
                db.SubmitChanges();
                Session["ThongBao"] = "003";
            }
            catch (Exception e)
            {
                Session["ThongBao"] = e.Message;
            }



            return RedirectToAction("Index");
        }
       
        
    }
}