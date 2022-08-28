using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Product
{
    public class SaveImageInAdminController : ApiController
    {
       
        public void PutSaveImage(Models.Image NewImage)
        {
            using (var context = new DbWatchShopEntities())
            {
                context.Images.Add(NewImage);
                context.SaveChanges();
            }
        }
    }
}
