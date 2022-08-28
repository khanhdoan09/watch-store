using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Product
{
    public class AddProductAdminController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();

        [HttpPut]
        public IHttpActionResult SaveAddProduct(Models.Product product)
        {
            Models.Product ProductEdit = new Models.Product
            {
                Name = product.Name,
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
            };
            using (var context = new DbWatchShopEntities())
            {
            
                context.Products.Add(ProductEdit);
                context.SaveChanges();
            }
            return Ok(ProductEdit.Id);
        }
    }
}
