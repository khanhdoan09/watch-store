using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatchStore.Models
{
    public class SharedProduct
    {
        public IEnumerable<Product> Origins { get; set; }
    }
}