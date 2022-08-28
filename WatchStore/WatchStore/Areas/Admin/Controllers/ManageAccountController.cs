using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers
{
    public class ManageAccountController : Controller
    {
        // GET: Admin/ManageAccount
        public ActionResult Index()
        {
            IEnumerable<Customer> customers = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("GetCustomerInAdmin");
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Customer>>();
                    readRe.Wait();
                    customers = readRe.Result;
                }

            }
            return View(customers);
        }
    }
}