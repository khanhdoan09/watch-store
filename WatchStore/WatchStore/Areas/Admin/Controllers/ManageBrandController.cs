using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers
{
    public class ManageBrandController : Controller
    {
        // GET: Admin/ManageBrand
        public ActionResult Index()

        {
            IEnumerable<Brand> brands = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("GetBrandAdmin");
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Brand>>();
                    readRe.Wait();
                    brands = readRe.Result;
                }

            }
            return View(brands);
        }

        [HttpPost]
        public ActionResult SaveAddBrand(string NameBrand)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    Brand brand = new Brand();
                    brand.Name = NameBrand;
                    client.BaseAddress = new Uri("https://localhost:44380/api/");
                    var rs = client.PutAsJsonAsync<Brand>("PutAddBrand", brand);
                    rs.Wait();
                    var re = rs.Result;
                    if (re.IsSuccessStatusCode)
                    {
                        var readRe = re.Content.ReadAsAsync<Brand>();
                        readRe.Wait();
                    }
                }
            }
            return RedirectToAction("Index", "ManageBrand", new { area = "Admin" });
        }

        public JsonResult DeleteBrand(String Id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var deleteTask = client.DeleteAsync("DeleteBrand?id=" + Id);
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readRe = result.Content.ReadAsAsync<string>();
                    readRe.Wait();
                    string message = readRe.Result;
                    return Json(new { text = message }, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { text = "remove fail" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditBrand(int IdBrand, string NameBrand)
        {

            using (var client = new HttpClient())
            {
                Brand brand = new Brand();
                brand.Id = IdBrand;
                brand.Name = NameBrand;
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.PutAsJsonAsync<Brand>("PutEditBrand", brand);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<Brand>();
                    readRe.Wait();
                }
            }
            return RedirectToAction("Index", "ManageBrand", new { area = "Admin" });
        }
    }
}