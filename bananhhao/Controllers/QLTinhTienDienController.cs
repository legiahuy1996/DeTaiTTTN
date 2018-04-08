using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bananhhao.Models;
namespace bananhhao.Controllers
{
    public class QLTinhTienDienController : Controller
    {
        // GET: QLTinhTienDien
        private DataClasses1DataContext db;
        public QLTinhTienDienController()
        {
            db = new DataClasses1DataContext();
        }
        public ActionResult Index(string makh,double sokwh)
        {
            List<khachhang> lst = db.khachhangs.Where(x=>x.makh == makh).ToList();
            return View(lst);
        }
        public double tinhtiendien(double sokwh)
        {
            Double sotien;
            if (sokwh < 0)
            {
                return 0;
            }
            else
            {
                if (sokwh > 0 && sokwh <= 100)
                {
                    sotien = sokwh * 1.242;
                }
                else if (sokwh > 100 && sokwh <= 150)
                {
                    sotien = 100 * 1.242 + (sokwh - 100) * 1.304;
                }
                else if (sokwh > 150 && sokwh <= 200)
                {
                    sotien = 100 * 1.242 + (150 - 100) * 1.304 + (200 - 150) * 1.651;
                }
                else if (sokwh > 200 && sokwh <= 300)
                {
                    sotien = 100 * 1.242 + (150 - 100) * 1.304 + (200 - 150) * 1.651 + (300 - 200) * 1.788;
                }
                else if (sokwh > 300 && sokwh <= 400)
                {
                    sotien = 100 * 1.242 + (150 - 100) * 1.304 + (200 - 150) * 1.651 + (300 - 200) * 1.788 + (400 - 300) * 1.912;
                }
                else
                {
                    sotien = 100 * 1.242 + (150 - 100) * 1.304 + (200 - 150) * 1.651 + (300 - 200) * 1.788 + (400 - 300) * 1.912 + (sokwh - 400) * 1.962;
                }
            }
            return sotien;

        }
    }
}