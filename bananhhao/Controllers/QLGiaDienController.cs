﻿using System;
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