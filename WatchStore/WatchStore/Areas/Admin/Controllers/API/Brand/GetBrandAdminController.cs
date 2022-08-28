using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Brand
{
    public class GetBrandAdminController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();
        public IHttpActionResult GetListBrand()
        {
            IList<Models.Brand> brands = db.Brands.ToList();
            return Ok(brands);
        }
    }
}
