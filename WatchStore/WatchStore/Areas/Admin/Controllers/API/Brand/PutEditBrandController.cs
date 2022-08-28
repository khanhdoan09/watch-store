using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Brand
{
    public class PutEditBrandController : ApiController
    {
        public IHttpActionResult PutEditBrand(Models.Brand brand)
        {
            Models.Brand brandEdit = brand;
            using (var context = new DbWatchShopEntities())
            {
                Models.Brand BrandSelected = context.Brands.SingleOrDefault(b => b.Id == brand.Id);
                if (BrandSelected != null)
                {
                    BrandSelected.Name = brand.Name;
                }
                context.SaveChanges();
            }
            return Ok();
        }
    }
}
