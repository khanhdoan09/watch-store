using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Product
{
    public class DeleteProductAdminController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int Id)
        {
            Models.Product productSelected = db.Products.SingleOrDefault(p => p.Id == Id);

            if (productSelected != null)
            {
                db.Products.Remove(productSelected);
                /* bug là do chưa set constraint trong csdl*/
                db.SaveChanges();
            }
            return Ok("delete successfully");
        }
    }
}
