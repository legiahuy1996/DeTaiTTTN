using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bananhhao.Models;

namespace bananhhao.Controllers
{
    public class QLHoaDonController : Controller
    {
        private DataClasses1DataContext db;
        public QLHoaDonController()
        {
            db = new DataClasses1DataContext();
        }
        // GET: QLHoaDon
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LapHoaDon(string makh,int diennangtieuthu,double tiendien,int chisocuoi,string mahd)
        {
            int mess = db.laphoadon(diennangtieuthu, tiendien, makh, mahd, chisocuoi);
            if (mess == 1)
            {
                Session["ThongBao"] = "Trùng mã hoá đơn";
            }
            else
                Session["ThongBao"] = "001";
            return RedirectToAction("Index","QLTinhTienDien");
        }
    }
}