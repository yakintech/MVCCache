using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CacheDesign.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration =10)]
        public ActionResult Index()
        {
            ViewBag.Date = DateTime.Now;
            return View();
        }
    }
}