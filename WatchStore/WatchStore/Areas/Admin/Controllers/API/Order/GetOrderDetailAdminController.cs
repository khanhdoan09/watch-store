using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Order
{
    public class GetOrderDetailAdminController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();
        public IHttpActionResult GetDetailProduct(int id)
        {
            IList<OrderDetail> orderDetail = db.OrderDetails.Where(od => od.OrderId == id).ToList();
            return Ok(orderDetail);
        }
    }
}
