using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Controllers.API
{
    public class ImageController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();

        public IHttpActionResult GetImageDetail()
        {
            IEnumerable<Image> imgs = db.Images.ToList();
            return Ok(imgs);
        }
        public IHttpActionResult GetImageDetail(string pid)
        {
            IEnumerable<Image> imgs = db.Images.Where(p => p.Product.Equals(pid)).Take(3).ToList();
            return Ok(imgs);
        }

    }
}
