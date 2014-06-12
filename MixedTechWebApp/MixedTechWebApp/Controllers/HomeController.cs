using MixedTechWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MixedTechWebApp.Controllers
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

        public ActionResult AngularDemo()
        {
            ViewBag.Message = "Simple Angular Demo";
            return View();
        }

        public ActionResult D3Demo()
        {
            ViewBag.Message = "Simple D3 Demo";
            return View();        
        }

        public ActionResult D3andAngular()
        {
            ViewBag.Message = "Simple D3 + Angular Demo";
            return View();        
        }

        public ActionResult RedisDemo()
        {
            ViewBag.Message = "Simple Redis Demo";
            return View(new RedisDemoModel());
        }

        public ActionResult SignalRDemo()
        {
            ViewBag.Message = "Simple SiganlR Demo";
            return View(); 
        }
    }
}