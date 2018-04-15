using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bananhhao.Models;

namespace bananhhao.Controllers
{
    public class TimkiemController : Controller
    {
        private DataClasses1DataContext db;
        public TimkiemController()
        {
            db = new DataClasses1DataContext();
        }
        // GET: Timkiemkh
        public ActionResult TimKiemKH(string khachhang)
        {
            khachhang kh = db.khachhangs.SingleOrDefault(x => x.makh == khachhang);
            List<khachhang> lst = new List<khachhang>();
            lst.Add(kh);
            return View(lst);
        }
        public ActionResult TimKiemDK(string dienke)
        {
            dienke dk = db.dienkes.SingleOrDefault(x => x.madk == dienke);
            List<dienke> lst = new List<dienke>();
            lst.Add(dk);
            return View(lst);
        }
    }
}