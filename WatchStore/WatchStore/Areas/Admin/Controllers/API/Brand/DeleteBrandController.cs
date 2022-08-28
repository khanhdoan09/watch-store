using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Brand
{
    public class DeleteBrandController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int Id)
        {
            Models.Brand brandSelected = db.Brands.SingleOrDefault(b => b.Id == Id);

            if (brandSelected != null)
            {
                db.Brands.Remove(brandSelected);
                db.SaveChanges();
            }
            return Ok("delete successfully");
        }
    }
}
