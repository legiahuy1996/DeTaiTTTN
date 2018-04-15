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
                return RedirectToAction("TimKiemKH", "Timkiem", new { @khachhang = kq.makh });
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
            //var kq = db.dienkes.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult TraCuuDienKe(string madk)
        {
            var result = db.dienkes.Count(x => x.madk == madk);
            if (result > 0)
            {
                var kq = db.dienkes.SingleOrDefault(x => x.madk == madk);
                return RedirectToAction("TimKiemDK", "Timkiem", new { @dienke = kq.madk });
            }
            else
            {
                Session["ThongBao"] = "Không có nhân viên nào trong đây!";
                return View();
            }
        }
    }
}