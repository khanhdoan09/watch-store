using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WatchStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.Title = "Cart";
            return View();
        }
        public  ActionResult Checkout()
        {
            return View();
        }
    }
}