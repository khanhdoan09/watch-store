using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers
{
    public class ManageProductController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index() 
        {
            IEnumerable<Product> products = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("GetListProductAdmin");
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
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(string Id)
        {
            Product product = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("EditProductAdmin?id=" + Id);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<Product>();
                    readRe.Wait();
                    product = readRe.Result;
                }

            }
            return View(product);
        }

        [HttpPost]
        public JsonResult SaveEditProduct(Product product)
        {
            if (ModelState.IsValid)
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44380/api/");
                    var rs = client.PutAsJsonAsync<Product>("EditProductAdmin", product);
                    rs.Wait();
                    var re = rs.Result;
                    if (re.IsSuccessStatusCode)
                    {
                        ChangeImageInFolder(product.Id);
                        return Json(new { text = "edit successfully"}, JsonRequestBehavior.AllowGet);
                    }

                }
            }

            return Json(new { text = "edit error" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveAddProduct(Product product)
        {
            int NewId = 0;
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44380/api/");
                    var rs = client.PutAsJsonAsync<Product>("AddProductAdmin", product);
                    rs.Wait();
                    var re = rs.Result;
                    if (re.IsSuccessStatusCode)
                    {
                        var readRe = re.Content.ReadAsAsync<int>();
                        readRe.Wait();
                        NewId = readRe.Result;
                        SaveImageInFolder(NewId);
                    }
                }
            }
            return RedirectToAction("Edit", "ManageProduct", new { area = "Admin", id = NewId });
        }
        private void SaveImageInFolder(int Id)
        {
            var i1 = Request.Files["image_1"];
            var i2 = Request.Files["image_2"];
            var i3 = Request.Files["image_3"];
            var i4 = Request.Files["image_4"];
            var i5 = Request.Files["image_5"];
            if (i1 != null)
            {
                string Extension = System.IO.Path.GetExtension(i1.FileName);
                var path1 = Server.MapPath("~/Content/img/product/cckt" + Id + "_1" + Extension);
                i1.SaveAs(path1);
                SaveAvatarToDatabase(Id, "cckt" +Id+"_1"+Extension);
            }
            if (i2 != null)
            {
                string Extension = System.IO.Path.GetExtension(i2.FileName);
                var path2 = Server.MapPath("~/Content/img/product/cckt" + Id + "_2" + Extension);
                i2.SaveAs(path2);
                SaveImageToDatabase("cckt" + Id + "_2" + Extension, Id);
            }
            if (i3 != null)
            {
                string Extension = System.IO.Path.GetExtension(i3.FileName);
                var path3 = Server.MapPath("~/Content/img/product/cckt" + Id + "_3" + Extension);
                i3.SaveAs(path3);
                SaveImageToDatabase("cckt" + Id + "_3" + Extension, Id);
            }
            if (i4 != null)
            {
                string Extension = System.IO.Path.GetExtension(i4.FileName);
                var path4 = Server.MapPath("~/Content/img/product/cckt" + Id + "_4" + Extension);
                i4.SaveAs(path4);
                SaveImageToDatabase("cckt" + Id + "_4" + Extension, Id);
            }
            if (i5 != null)
            {
                string Extension = System.IO.Path.GetExtension(i5.FileName);
                var path5 = Server.MapPath("~/Content/img/product/cckt" + Id + "_5" + Extension);
                i5.SaveAs(path5);
                SaveImageToDatabase("cckt" + Id + "_5" + Extension, Id);
            }
        }

        public void SaveAvatarToDatabase(int IdProduct, string NewAvatar)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                Avatar avatar = new Avatar(IdProduct, NewAvatar);
                var rs = client.PutAsJsonAsync<Avatar>("SaveAvatarInAdmin", avatar);
                rs.Wait();
            }
        }

        private void SaveImageToDatabase(string Url, int IdProduct)
        {
            using (var client = new HttpClient())
            {
                Image NewImage = new Image();
                NewImage.Url = Url;
                NewImage.Product = IdProduct;

                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.PutAsJsonAsync<Image>("SaveImageInAdmin", NewImage);
                rs.Wait();
            }
        }

        private void ChangeImageInFolder(int Id)
        {
            var i1 = Request.Files["image_1"];
            var i2 = Request.Files["image_2"];
            var i3 = Request.Files["image_3"];
            var i4 = Request.Files["image_4"];
            var i5 = Request.Files["image_5"];
            if (i1 != null)
            {
                string Extension = System.IO.Path.GetExtension(i1.FileName);
                var path1 = Server.MapPath("~/Content/img/product/" + Id + "_1" + Extension);
                i1.SaveAs(path1);
            }
            if (i2 != null)
            {
                string Extension = System.IO.Path.GetExtension(i2.FileName);
                var path2 = Server.MapPath("~/Content/img/product/" + Id + "_2"+Extension);
                i2.SaveAs(path2);
            }
            if (i3 != null)
            {
                string Extension = System.IO.Path.GetExtension(i3.FileName);
                var path3 = Server.MapPath("~/Content/img/product/" + Id + "_3"+Extension);
                i3.SaveAs(path3);
            }
            if (i4 != null)
            {
                string Extension = System.IO.Path.GetExtension(i4.FileName);
                var path4 = Server.MapPath("~/Content/img/product/" + Id + "_4"+Extension);
                i4.SaveAs(path4);
            }
            if (i5 != null)
            {
                string Extension = System.IO.Path.GetExtension(i5.FileName);
                var path5 = Server.MapPath("~/Content/img/product/" + Id + "_5"+Extension);
                i5.SaveAs(path5);
            }
        }
      
        public ActionResult ViewP(String id)
        {
            Product product = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("GetDetailProductAdmin?id=" + id);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<Product>();
                    readRe.Wait();
                    product = readRe.Result;
                }

            }
            return View(product);
        }

        public JsonResult DeleteProduct(String Id)
        {
            Product product = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var deleteTask = client.DeleteAsync("DeleteProductAdmin?id=" + Id);
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


        /*
                public IEnumerable<Customer> listAccount()
                {
                    ViewBag.Title = "Product";
                    IEnumerable<Customer> customers = null;

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44380/api/");
                        var rs = client.GetAsync("manageaccount");
                        rs.Wait();
                        var re = rs.Result;
                        if (re.IsSuccessStatusCode)
                        {
                            var readRe = re.Content.ReadAsAsync<IList<Customer>>();
                            readRe.Wait();
                            customers = readRe.Result;
                        }

                    }
                    return customers;
                }
                public IEnumerable<Brand> listBrand()
                {
                    ViewBag.Title = "Product";
                    IEnumerable<Brand> brands = null;

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44380/api/");
                        var rs = client.GetAsync("managebrand");
                        rs.Wait();
                        var re = rs.Result;
                        if (re.IsSuccessStatusCode)
                        {
                            var readRe = re.Content.ReadAsAsync<IList<Brand>>();
                            readRe.Wait();
                            brands = readRe.Result;
                        }

                    }
                    return brands;
                }
                public IEnumerable<Product> listProduct()

                {
                    ViewBag.Title = "Product";
                    IEnumerable<Product> products = null;

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44380/api/");
                        var rs = client.GetAsync("manageproduct");
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

                public IEnumerable<Order> listOrder()

                {
                    ViewBag.Title = "Product";
                    IEnumerable<Order> orders = null;

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44380/api/");
                        var rs = client.GetAsync("manageorder");
                        rs.Wait();
                        var re = rs.Result;
                        if (re.IsSuccessStatusCode)
                        {
                            var readRe = re.Content.ReadAsAsync<IList<Order>>();
                            readRe.Wait();
                            orders = readRe.Result;
                        }

                    }
                    return orders;
                }*/
    }
}