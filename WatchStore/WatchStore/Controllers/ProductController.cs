using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WatchStore.Models;

namespace WatchStore.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult Index()

        {
            ViewBag.Title = "Product";
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
            return View(products);
        }
        public ActionResult Brand(string bid)
        {
            IEnumerable<Product> products = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?bid=" + bid);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return View(products);
        }
        public ActionResult Gender(String gen)
        {
            IEnumerable<Product> products = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?gen=" + gen);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return View(products);
        }
        public ActionResult Detail(string pid)
        {
            Product p = GetDetail(pid);
            IEnumerable<Product> products = GetProductByBestSeller();
            IEnumerable<Image> imgs = GetImages(pid);
            SharedProductDetail spd = new SharedProductDetail(p, products, imgs);
            return View(spd);
        }
        public Product GetDetail(string pid)
        {
            Product pu = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?pid=" + pid);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<Product>();
                    readRe.Wait();
                    pu = readRe.Result;
                }

            }
            return pu;
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
        public IEnumerable<Image> GetImages(string pid)
        {
            IEnumerable<Image> imgs = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("image?pid" + pid);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Image>>();
                    readRe.Wait();
                    imgs = readRe.Result;
                }

            }
            return imgs;
        }
        public ActionResult BestDeal()
        {
            IEnumerable<Product> products = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?deal=5");
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return View(products);
        }
        public ActionResult Rich()
        {
            IEnumerable<Product> products = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?rich=5");
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return View(products);
        }

        public ActionResult Origin(string origin)
        {
            IEnumerable<Product> products = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?origin=" + origin);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return View(products);
        }
        public ActionResult Waterproof(string waterproof)
        {
            IEnumerable<Product> products = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?waterproof=" + waterproof);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return View(products);
        }
        public ActionResult Price(double price)
        {
            IEnumerable<Product> products = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?price=" + price);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }
            }
            return View(products);
        }
        // tim kiem san pham theo ten
        public ActionResult Search(string txtName)
        {
            IEnumerable<Product> products = null;
            ViewBag.textSearch = txtName;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("product?txtName=" + txtName);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }
                

            }
            
            return View(products);
        }

    }
}