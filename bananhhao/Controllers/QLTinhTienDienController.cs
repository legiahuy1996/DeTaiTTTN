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
        public ActionResult Index()
        {
            List<khachhang> lst = db.khachhangs.ToList();
            return View(lst);
        }

    }
}