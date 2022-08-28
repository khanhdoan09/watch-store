using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers
{
    public class ManageOrderController : Controller
    {
        // GET: Admin/ManageOrder
        public ActionResult Index()
        {
            IEnumerable<Order> orders = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("GetOrderAdmin");
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Order>>();
                    readRe.Wait();
                    orders = readRe.Result;
                }

            }
            return View(orders);
        }
      
        public ActionResult ViewO(int id)
        {
            IEnumerable<OrderDetail> OrderDetail = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("GetOrderDetailAdmin?id=" + id);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<OrderDetail>>();
                    readRe.Wait();
                    OrderDetail = readRe.Result;
                }

            }
            return View(OrderDetail);
        }
    }
}