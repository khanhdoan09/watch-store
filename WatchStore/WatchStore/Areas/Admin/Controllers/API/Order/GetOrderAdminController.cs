using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Order
{
    public class GetOrderAdminController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();
        public IHttpActionResult GetListOrder()
        {
            IList<Models.Order> orders = db.Orders.ToList();
            return Ok(orders);
        }
    }
}
