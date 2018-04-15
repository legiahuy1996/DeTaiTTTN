using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bananhhao.Models;
namespace bananhhao.Controllers
{
    public class TraCuuController : Controller
    {
        private DataClasses1DataContext db;
        public TraCuuController()
        {
            db = new DataClasses1DataContext();
        }
        // GET: TraCuu
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TimKiemKhachHang()
        {
            //;var kq = db.khachhangs.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult TimKiemKhachHang(string makh)
        {
            var result = db.khachhangs.Count(x => x.makh == makh);
            if (result > 0)
            {
                var kq = db.khachhangs.SingleOrDefault(x => x.makh == makh);
                return RedirectToAction("TimKiemKH", "timkiemkh", new { @khachhang = kq.makh });
            }    
            else
            {
                Session["ThongBao"] = "Không có nhân viên nào trong đây!";
                return View();
            }    
                
            
        }
        [HttpGet]
        public ActionResult TraCuuDienKe()
        {
            var kq = db.dienkes.ToList();
            return View(kq);
        }
        [HttpPost]
        public ActionResult TraCuuDienKe(string madk)
        {
            var kq = db.dienkes.Where(x => x.madk == madk).ToList();
            if(kq == null)
            {
                Session["ThongBao"] = "Không tồn tại điện kế nào trong đây!";
                return View("TraCuuDienKe");
            }
            return View(kq);
        }
    }
}