using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bananhhao.Models;
namespace bananhhao.Controllers
{
    public class QLGiaDienController : Controller
    {
        private DataClasses1DataContext db;
        // GET: QLGiaDien
        public QLGiaDienController()
        {
            db = new DataClasses1DataContext();
        }
        public ActionResult Index()
        {
             List<giadien>lst =db.giadiens.ToList();
            return View(lst);
        }
        [HttpGet]
        public ActionResult Insert()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Insert(giadien gd)
        {
            if (db.giadiens.SingleOrDefault(x => x.mabac == gd.mabac) !=null)
            {
                Session["ThongBao"] = "Mã bậc đã tồn tại";
                return View("Insert");
            }
            //else if (dk.madk.Length != 8 || dk.makh.Length == 0 || dk.ngaysx > DateTime.Now || dk.ngaylap > DateTime.Now || dk.ngaysx >= dk.ngaylap || dk.mota == null)
            //{
              //  Session["ThongBao"] = "Thông tin nhập ko hợp lệ!";
                //return View("Insert");
            //}
            else
            {
                try
                {
                    db.giadiens.InsertOnSubmit(gd);
                    db.SubmitChanges();
                    Session["ThongBao"] = "001";
                }
                catch (Exception e)
                {
                    Session["ThongBao"] = e.Message;
                    return View("Insert");
                }
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult Edit()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Edit(giadien gd)
        {
            giadien a = db.giadiens.SingleOrDefault(x => x.mabac == gd.mabac);
            a = gd;
            db.SubmitChanges();
            Session["ThongBao"] = "001";
            return RedirectToAction("Index");
        }
    }
}