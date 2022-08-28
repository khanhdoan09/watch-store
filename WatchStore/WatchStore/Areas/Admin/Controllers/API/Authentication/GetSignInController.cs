using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Authentication
{
    public class GetSignInController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();
        [HttpGet]
        public IHttpActionResult GetSignIn(string Email, string Password)
        {
            string EncryptedPassword = ToEncryptedPassword(Password);
            Models.Customer user = db.Customers.Where(u =>u.isAdmin == 1 && u.Email.Equals(Email) && u.Password.Equals(EncryptedPassword)).ToList().FirstOrDefault();
            if (user != null)
            {
                return Ok();
            }
            return NotFound();
        }

        public string ToEncryptedPassword(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));
            }
            return sbHash.ToString();
        }

    }
}
