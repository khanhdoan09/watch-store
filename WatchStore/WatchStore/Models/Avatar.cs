using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatchStore.Models
{
    public class Avatar
    {
        public Avatar(int idProduct, string url)
        {
            this.IdProduct = idProduct;
            this.Url = url;
        }

        public int IdProduct { get; set; }
        public string Url { get; set; }
    }
}