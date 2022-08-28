using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Product
{
    public class GetDetailProductAdminController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();
        public IHttpActionResult GetListProduct(int id)
        {
            Models.Product product = db.Products.Where(p => p.Id == id).FirstOrDefault();
            return Ok(product);
        }
    }
}
