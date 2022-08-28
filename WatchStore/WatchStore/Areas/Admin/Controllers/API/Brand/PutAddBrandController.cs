using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Brand
{
    public class PutAddBrandController : ApiController
    {
        public IHttpActionResult PutAddBrand(Models.Brand brand)
        {
            using (var context = new DbWatchShopEntities())
            {

                context.Brands.Add(brand);
                context.SaveChanges();
            }
            return Ok();
        }
    }
}
