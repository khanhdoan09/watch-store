using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WatchStore.Models;

namespace WatchStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index( )
        {
            ViewBag.Title = "Home";
           
            IEnumerable<Product> seller = GetProductByBestSeller();
            IEnumerable<Product> newArrival = GetProductByNewArrival();
            IEnumerable<Product> popular = GetProductPopular();

            IEnumerable<Product> onSale = GetProductByOnSale();
            SharedHome sh = new SharedHome(seller, newArrival, popular, onSale);
            return View(sh);
        }
        public IEnumerable<Product> GetProductByBestSeller()
        {
            IEnumerable<Product> products = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product");
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return products;
        }
        public IEnumerable<Product> GetProductByOnSale()
        {
            IEnumerable<Product> products = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?numSale=30" );
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return products;
        }
        public IEnumerable<Product> GetProductPopular()
        {
            IEnumerable<Product> products = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?popular=5");
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return products;
        }
        public IEnumerable<Product> GetProductByNewArrival()
        {
            IEnumerable<Product> products = null;
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?da=2/8/2015 10:52:03 PM");
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return products;
        }
     
    }
}
