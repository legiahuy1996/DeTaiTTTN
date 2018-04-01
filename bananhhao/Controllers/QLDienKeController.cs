using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bananhhao.Models;
namespace bananhhao.Controllers
{
    public class QLDienKeController : Controller
    {
        private DataClasses1DataContext db;
        public QLDienKeController()
        {
            db = new DataClasses1DataContext();
        }
        // GET: QLDienKe
        public ActionResult Index()
        {
            List<dienke> lst = db.dienkes.ToList( );
            return View(lst);
        }
        [HttpGet]
        public ActionResult Insert()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Insert(dienke dk)
        {
            if (db.dienkes.SingleOrDefault(x => x.madk == dk.madk) != null)
            {
                Session["ThongBao"] = "Mã điện kế đã tồn tại";
                return View("Insert");
            }
            else if (dk.madk.Length != 8 || dk.makh.Length == 0 || dk.ngaysx > DateTime.Now || dk.ngaylap > DateTime.Now || dk.ngaysx >= dk.ngaylap || dk.mota == null)
            {
                Session["ThongBao"] = "Thông tin nhập ko hợp lệ!";
                return View("Insert");
            }
            else
            {
                try
                {
                    db.dienkes.InsertOnSubmit(dk);
                    db.SubmitChanges();
                    Session["ThongBao"] = "001";
                }
                catch(Exception e)
                {
                    Session["ThongBao"] = e.Message;
                    return View("Insert");
                }
                return RedirectToAction("Index");
            }
          
        }
    }
}