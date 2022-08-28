using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Product
{
    public class SaveAvatarInAdminController : ApiController
    {
        public void PutSaveAvatar(Avatar avatar)
        {
            using (var context = new DbWatchShopEntities())
            {
                Models.Product ProductSelected = context.Products.SingleOrDefault(p => p.Id == avatar.IdProduct);

                if (ProductSelected != null)
                {
                    ProductSelected.Avatar = avatar.Url;
                }
                context.SaveChanges();
            }
        }
    }
}
