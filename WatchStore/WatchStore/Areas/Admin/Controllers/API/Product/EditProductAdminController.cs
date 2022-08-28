using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Product
{
    public class EditProductAdminController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();
     

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEditProduct(int id)
        {
            Models.Product Product = db.Products.Where(p => p.Id == id).FirstOrDefault();
            return Ok(Product);
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult SaveEditProduct(Models.Product product)
        {
            Models.Product productEdit = product;
            using (var context = new DbWatchShopEntities())
            {
                Models.Product ProductSelected = context.Products.SingleOrDefault(p => p.Id == product.Id);

                if (ProductSelected != null)
                {
                    ProductSelected.Name = productEdit.Name;
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
                    ProductSelected.UpdateDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                }
                context.SaveChanges();
            }
            return Ok();
        }



    }
}
