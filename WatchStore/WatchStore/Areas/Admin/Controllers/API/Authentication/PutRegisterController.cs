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
    public class PutRegisterController : ApiController
    {
        public IHttpActionResult PutRegister(Models.Customer customer)
        {
            using (var context = new DbWatchShopEntities())
            {
                customer.isAdmin = 1; // register new admin
                string encryptedPassword = ToEncryptedPassword(customer.Password);
                customer.Password = encryptedPassword;
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            return Ok();
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
