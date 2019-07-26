using JayGervais_CPRG215_MVC_Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JayGervais_CPRG215_MVC_Lab3.Controllers
{
    public class HomeController : Controller
    {
        List<Product> products = null;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            products = ProductDB.GetProducts();

            double total = 0;
            foreach (Product p in products)
            {
                total += p.UnitPrice * p.OnHand;
            }         
            ViewBag.Inventory = total.ToString("C");

            return View(products);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return View(ProductDB.ProductDetails(id));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }    
        }

        public ActionResult About()
        {
            ViewBag.Message = "Halloween Superstore MVC C# Assignment from Jay Gervais";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Get in touch with an incredible software developer today!";

            return View();
        }
    }
}