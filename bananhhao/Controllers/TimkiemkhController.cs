using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bananhhao.Models;

namespace bananhhao.Controllers
{
    public class TimkiemkhController : Controller
    {
        private DataClasses1DataContext db;
        public TimkiemkhController()
        {
            db = new DataClasses1DataContext();
        }
        // GET: Timkiemkh
        public ActionResult TimKiemKH(string khachhang)
        {

            //    vcc bạn Hào là sao éo hiểu ???? trang này của tao là khi nhập đúng ma thì nó trả về đây để lấy thông tin
            khachhang kh = db.khachhangs.SingleOrDefault(x => x.makh == khachhang);
            List<khachhang> lst = new List<khachhang>();
            lst.Add(kh);
            return View(lst);
        }
    }
}