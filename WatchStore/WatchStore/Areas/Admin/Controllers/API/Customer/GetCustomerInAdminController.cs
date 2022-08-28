using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Customer
{
    public class GetCustomerInAdminController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();
        public IHttpActionResult GetListCustomer()
        {
            IList<Models.Customer> customers = db.Customers.ToList();
            return Ok(customers);
        }
    }
}
