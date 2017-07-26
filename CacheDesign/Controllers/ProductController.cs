using CacheDesign.Models;
using CacheDesign.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CacheDesign.Controllers
{
    public class ProductController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        public ActionResult Index()
        {
            CachedModelsRepository Repository = new CachedModelsRepository();

            List<Product> plist = Repository.GetProducts();

            return View(plist);
        }



        [OutputCache(Duration = 20, VaryByParam = "id")]
        public ActionResult ProductDetail(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.ProductID == id);
            return View(product);
        }
    }
}