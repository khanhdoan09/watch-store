using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Authentication
{
    public class GetCheckEmailController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();
        public IHttpActionResult GetCheckEmailExist(string Email)
        {
            Models.Customer user = db.Customers.Where(u => u.isAdmin == 1 && u.Email.Equals(Email)).ToList().FirstOrDefault();
            if (user != null)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
