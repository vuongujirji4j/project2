﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22cntt3_pvv_project2.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public ActionResult Index()
        //{
        //    if (Session["Tai_khoan"] == null)
        //    {
        //        return RedirectToAction("Index", "Login");
        //    }
        //    return View();
        //}

    }
}