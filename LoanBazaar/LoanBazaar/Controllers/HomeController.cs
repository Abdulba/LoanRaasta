﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanBazaar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inner()
        {
            return View();
        }

        public ActionResult UnderCons()
        {
            return View();
        }

        public ActionResult ApplyLoan()
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

        public ActionResult Careers()
        {
            return View();
        }

        public ActionResult Banks()
        {
            return View();
        }

    }
}