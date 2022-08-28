using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatchStore.Models
{
    public class ShareViewProduct
    {
        public Product product { get; set; }
        public IEnumerable<Image> listI { get; set; }
        public ShareViewProduct (Product p, IEnumerable<Image> i)
        {
            this.product = p;
            this.listI = i;
        }
    }
}