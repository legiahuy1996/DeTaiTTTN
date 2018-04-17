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
        public ActionResult Edit(int id)
        {
            giadien kh = db.giadiens.SingleOrDefault(x => x.mabac == id);
            return View(kh);
        }
        [HttpPost]
        public ActionResult Edit(int mabac, string tenbac, int tusokw, int densokw, decimal dongia,DateTime ngayapdung)
        {
            giadien save = new giadien { mabac = mabac, tenbac = tenbac, tusokw = tusokw, densokw = densokw, dongia = dongia, ngayapdung=ngayapdung };
            giadien check = db.giadiens.SingleOrDefault(x => x.mabac == mabac);
            try
            {

                if (mabac == 0 || tenbac == null || tusokw == 0 || densokw == 0|| dongia == 0 && ngayapdung==null)
                {
                    Session["ThongBao"] = "Có lỗi khi sửa giá điện";
                    return RedirectToAction("Edit", new { id = mabac });
                }
                /*else if (check != null)
                {
                    Session["ThongBao"] = "Số chứng minh đã tồn tại!";
                    return RedirectToAction("Edit", new { id = makh });
                }*/
                giadien kh = db.giadiens.SingleOrDefault(x => x.mabac == mabac);

                kh.tenbac = tenbac;
                kh.tusokw = tusokw;
                kh.densokw = densokw;
                kh.dongia = dongia;
                kh.ngayapdung = ngayapdung;
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
        public ActionResult Delete(int mabac)
        {
            try
            {
                giadien kh = db.giadiens.SingleOrDefault(x => x.mabac == mabac);

                db.giadiens.DeleteOnSubmit(kh);
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