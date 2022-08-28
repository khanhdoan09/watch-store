using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatchStore.Models
{
    public class SharedManage
    {
        public IEnumerable<Product> listP { get; set; }
        public IEnumerable<Customer> listC { get; set; }

        public IEnumerable<Brand> listB { get; set; }
        public IEnumerable<Order> listO { get; set; }
        public SharedManage(IEnumerable<Product> p, IEnumerable<Customer> c, IEnumerable<Brand> b, IEnumerable<Order> o)
        {
            this.listP = p;
            this.listC = c;
            this.listB = b;
            this.listO = o;
        }
    }
}