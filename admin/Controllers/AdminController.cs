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
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveEditProduct(ProductDetailAdmin productDetail, string IdOld)
        {
           
            Product productEdit = productDetail.Product;
            using (var context = new DbWatchShopEntities())
            {
                Product ProductSelected = context.Products.SingleOrDefault(p => p.Id == IdOld);

                if (ProductSelected != null)
                {
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

            return Json(new { text = "edit success" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditProduct(string Id)
        {
            ViewBag.IdEditProduct = Id;
            List<Product> ListProduct = null;
            List<Image> ListImage = null;
            using (var context = new DbWatchShopEntities())
            {
                ListProduct = (from product in context.Products
                               where product.Id == Id
                               select product).ToList();
            }
            using (var context = new DbWatchShopEntities())
            {
                ListImage = (from image in context.Images
                             where image.Product == Id
                             select image).ToList();
            }
            ProductDetailAdmin ProductDetail = new ProductDetailAdmin(ListProduct[0], ListImage);
            return View(ProductDetail);
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
                return Json(new {text="remove success"}, JsonRequestBehavior.AllowGet);
            
        }
        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult SaveAddProduct(Product product)
    {

        var i1 = Request.Files["image1"];
        var i2 = Request.Files["image2"];
        var i3 = Request.Files["image3"];
        var i4 = Request.Files["image4"];
        var i5 = Request.Files["image5"];

        if (i1 != null && i2 != null && i3 != null && i4 != null && i5 != null)
        {
            var path1 = Server.MapPath("~/Content/image/product/" + product.Id+"_1.jpg");
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
                   /*
                    List<Image> images = new List<Image>()
                    {
                        new Image("", product.Id + "_1.jpg", product.Id),
                        new Image("", product.Id + "_2.jpg", product.Id),
                        new Image("", product.Id + "_3.jpg", product.Id),
                        new Image("", product.Id + "_4.jpg", product.Id),
                        new Image("", product.Id + "_5.jpg", product.Id)
                    };
                    context.Images.AddRange(images);
                   */
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
            List<Product> ListProduct = null;
            List<Image> ListImage = null;
            using (var context = new DbWatchShopEntities())
            {
                ListProduct = (from product in context.Products
                               where product.Id == Id
                               select product).ToList();
            }
            using (var context = new DbWatchShopEntities())
            {
                ListImage = (from image in context.Images
                             where image.Product == Id
                             select image).ToList();
            }
            ProductDetailAdmin ProductDetail = new ProductDetailAdmin(ListProduct[0], ListImage);
            return View(ProductDetail);
        }

        public ActionResult GetProduct(String type, String search)
        {

            List<Product> ListProduct = null;
            using (var context = new DbWatchShopEntities())
            {
                ListProduct = (from product in context.Products
                               where product.Name.Contains(search)
                               select product).ToList();
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


        }*/



        public ActionResult GetUserList()
        {
            return View();
        }
        public ActionResult OrderInAdmin()
        {
            return View();
        }

    }
}