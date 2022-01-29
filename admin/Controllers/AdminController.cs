using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.Models;

namespace WatchShop.Controllers
{
    public class AdminController : Controller
    {

        // USER
        public ActionResult GetUserList(string Id)
        {
            List<Customer> ListUser = null;
            using (var context = new DbWatchShopEntities())
            {
                ListUser = (from customer in context.Customers
                            select customer).ToList();
            }
            return View(ListUser);
        }

        public JsonResult RemoveCustomer(string Id)
        {
            using (var context = new DbWatchShopEntities())
            {
                Customer productSelected = context.Customers.SingleOrDefault(p => p.Id == Id);

                if (productSelected != null)
                {
                    context.SaveChanges();
                }
            }

            return Json(new { text = "remove customer successfully" }, JsonRequestBehavior.AllowGet);

        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // ORDER
        public ActionResult GetOrderList()
        {
            List<Order> ListOrder = null;
            using (var context = new DbWatchShopEntities())
            {
                ListOrder = (from order in context.Orders
                             select order).ToList();
            }
            return View(ListOrder);
        }

        public ActionResult GetOrderDetail(string Id)
        {
            var context = new DbWatchShopEntities();

            var res = (from o in context.Orders
                       join od in context.OrderDetails
                       on o.Id equals od.OrderId
                       join p in context.Products
                       on od.Product equals p.Id
                       where o.Id == Id
                       select od).ToList();
            return View(res);

        }


        // PRODUCT

        [HttpPost]
        public JsonResult SaveEditProduct(Product product, string IdOld)
        {
            if (ModelState.IsValid)
            {
                Product productEdit = product;
                using (var context = new DbWatchShopEntities())
                {
                    Product ProductSelected = context.Products.SingleOrDefault(p => p.Id == IdOld);

                    if (ProductSelected != null)
                    {


                        var i1 = Request.Files["image_1"];
                        var i2 = Request.Files["image_2"];
                        var i3 = Request.Files["image_3"];
                        var i4 = Request.Files["image_4"];
                        var i5 = Request.Files["image_5"];
                        if (i1 != null)
                        {
                            var path1 = Server.MapPath("~/Content/image/product/" + product.Id.ToLower() + "_1.jpg");
                            i1.SaveAs(path1);
                        }
                        if (i2 != null)
                        {
                            var path2 = Server.MapPath("~/Content/image/product/" + product.Id.ToLower() + "_2.jpg");
                            i2.SaveAs(path2);
                        }
                        if (i3 != null)
                        {
                            var path3 = Server.MapPath("~/Content/image/product/" + product.Id.ToLower() + "_3.jpg");
                            i3.SaveAs(path3);
                        }
                        if (i4 != null)
                        {
                            var path4 = Server.MapPath("~/Content/image/product/" + product.Id.ToLower() + "_4.jpg");
                            i4.SaveAs(path4);
                        }
                        if (i5 != null)
                        {
                            var path5 = Server.MapPath("~/Content/image/product/" + product.Id.ToLower() + "_5.jpg");
                            i5.SaveAs(path5);
                        }




                        ProductSelected.Name = productEdit.Name;
                        ProductSelected.Avatar = productEdit.Avatar;
                        ProductSelected.Price = productEdit.Price;
                        ProductSelected.Discount = productEdit.Discount;
                        ProductSelected.Import = productEdit.Import;
                        ProductSelected.Stock = productEdit.Stock;
                        ProductSelected.Brand = productEdit.Brand;
                        ProductSelected.Gender = productEdit.Gender;
                        ProductSelected.Origin = productEdit.Origin;
                        ProductSelected.WarrantyPeriod = productEdit.WarrantyPeriod;
                        ProductSelected.Diameter = productEdit.Diameter;
                        ProductSelected.Material = productEdit.Material;
                        ProductSelected.Strap = productEdit.Strap;
                        ProductSelected.WireWidth = productEdit.WireWidth;
                        ProductSelected.Apparatus = productEdit.Apparatus;
                        ProductSelected.Waterproof = productEdit.Waterproof;
                        ProductSelected.Description = productEdit.Description;
                        ProductSelected.CreateDate = productEdit.CreateDate;
                    }

                    /*
                    List<Image> ListImage = (from image in context.Images
                                         where image.Product == IdOld
                                         select image).ToList(); 
                    if (ListImage != null)
                    {

                    }*/
                    context.SaveChanges();
                }

            }


            return Json(new { text = "edit success" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditProduct(string Id)
        {
            ViewBag.IdEditProduct = Id;
            Product Product = null;
            var context = new DbWatchShopEntities();
            Product = (from product in context.Products
                       join image in context.Images
                       on product.Id equals image.Product
                       join brand in context.Brands
                       on product.Brand equals brand.Id
                       where product.Id == Id
                       select product).FirstOrDefault();
            return View(Product);
        }

        public JsonResult RemoveProduct(string Id)
        {
            using (var context = new DbWatchShopEntities())
            {
                Product productSelected = context.Products.SingleOrDefault(p => p.Id == Id);

                Image imageSelected = context.Images.FirstOrDefault(i => i.Product == Id);

                if (productSelected != null && imageSelected != null)
                {
                    context.Products.Remove(productSelected);
                    context.SaveChanges();
                }
            }

            var json = JsonConvert.SerializeObject(null);
            return Json(new { text = "remove success" }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult SaveAddProduct(Product product)
        {

            if (product != null)
            {
                var i1 = Request.Files["image1"];
                var i2 = Request.Files["image2"];
                var i3 = Request.Files["image3"];
                var i4 = Request.Files["image4"];
                var i5 = Request.Files["image5"];
                var path1 = Server.MapPath("~/Content/image/product/" + product.Id + "_1.jpg");
                i1.SaveAs(path1);
                var path2 = Server.MapPath("~/Content/image/product/" + product.Id + "_2.jpg");
                i2.SaveAs(path2);
                var path3 = Server.MapPath("~/Content/image/product/" + product.Id + "_3.jpg");
                i3.SaveAs(path3);
                var path4 = Server.MapPath("~/Content/image/product/" + product.Id + "_4.jpg");
                i4.SaveAs(path4);
                var path5 = Server.MapPath("~/Content/image/product/" + product.Id + "_5.jpg");
                i5.SaveAs(path5);
                ViewBag.LinkImg1 = i1.FileName;
                ViewBag.LinkImg2 = i2.FileName;
                ViewBag.LinkImg3 = i3.FileName;
                ViewBag.LinkImg4 = i4.FileName;
                ViewBag.LinkImg5 = i5.FileName;

                using (var context = new DbWatchShopEntities())
                {
                    var IsExistBrand = context.Brands.FirstOrDefault(brand => brand.Name==product.Brand);
                    // neu chua co brand thi them brand moi
                    if (IsExistBrand == null)
                    {
                        int length = context.Brands.Count() + 1;
                        context.Brands.Add(new Brand { 
                            Id = "B"+length,
                            Name = product.Brand 
                        });
                        product.Brand = "B" + length;
                    }

                    context.Products.Add(new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Avatar = product.Avatar,
                        Price = product.Price,
                        Discount = product.Discount,
                        Import = product.Import,
                        Stock = product.Stock,
                        Brand = product.Brand,
                        Gender = product.Gender,
                        Origin = product.Origin,
                        WarrantyPeriod = product.WarrantyPeriod,
                        Diameter = product.Diameter,
                        Material = product.Material,
                        Strap = product.Strap,
                        WireWidth = product.WireWidth,
                        Apparatus = product.Apparatus,
                        Waterproof = product.Waterproof,
                        Description = product.Description,
                        CreateDate = product.CreateDate
                    });
                  
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("Id", "Id already exists.");
                    }


                    ViewBag.Id = product.Id;
                    ViewBag.Name = product.Name;
                    ViewBag.Description = product.Description;
                }
            }

            return View("AddProduct");

        }

        public ActionResult ViewProduct(string Id)
        {
            Product Product = null;
            var context = new DbWatchShopEntities();
            Product = (from product in context.Products
                       join image in context.Images
                       on product.Id equals image.Product
                       join brand in context.Brands
                       on product.Brand equals brand.Id
                       where product.Id == Id
                       select product).FirstOrDefault();
            return View(Product);
        }

        public ActionResult GetProduct(String type, String search)
        {

            if (type == null) {
                return View(new List<Product>());
            }
            List<Product> ListProduct = null;
            using (var context = new DbWatchShopEntities())
            {
                if (type.Equals("Id"))
                {
                    ListProduct = (from product in context.Products
                                   where product.Id == search
                                   select product).ToList();
                }
                else if (type.Equals("Name"))
                {
                    ListProduct = (from product in context.Products
                                   where product.Name.Contains(search)
                                   select product).ToList();
                }
                else if (type.Equals("Brand"))
                {
                    ListProduct = (from product in context.Products
                                   where product.Brand1.Name == search
                                   select product).ToList();
                }
                ViewBag.Type = type;
                ViewBag.Search = search;    
            }
            return View(ListProduct);
        }

        /*
        [HttpPost]
        public JsonResult ResponseListProductToAjax(String type, String search)
        {


            using (var context = new DbWatchShopEntities())
            {

                var ListProduct = (from product in context.Products
                                   where product.Name.Contains("Titan")
                                   select product);

                var json = JsonConvert.SerializeObject(ListProduct.ToArray());
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }
        */


    }


}