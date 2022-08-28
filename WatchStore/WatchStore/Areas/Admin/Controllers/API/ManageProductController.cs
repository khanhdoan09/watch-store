using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API
{
    public class ManageProductController : ApiController
    {
   /*     DbWatchShopEntities db = new DbWatchShopEntities();
        public IHttpActionResult GetProduct()
        {
            IList<Product> products = db.Products.OrderByDescending(p => p.CreateDate).ToList();
            return Ok(products);
        }
        public IHttpActionResult GetProductDetails(string pid)
        {
            Product products = db.Products.Where(p => p.Id.Equals(pid)).FirstOrDefault();
            return Ok(products);
        }
        public IHttpActionResult GetImagesProduct(string iid)
        {
            IList<Image> images = db.Images.Where(p => p.Product.Equals(iid)).ToList();
            return Ok(images);
        }*/
    }
}
