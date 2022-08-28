using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatchStore.Models
{
    public class SharedHome
    {
        public IEnumerable<Product> BestSeller { get; set; }
        public IEnumerable<Product> NewArrival { get; set; }
        public IEnumerable<Product> Popular { get; set; }
        public IEnumerable<Product> OnSale { get; set; }

        public SharedHome( IEnumerable<Product> productsBestSeller, IEnumerable<Product> productsNewArrival,
            IEnumerable<Product> productsPopular, IEnumerable<Product> productsOnSale)
        {         
            this.BestSeller = productsBestSeller;
            this.NewArrival = productsNewArrival;
            this.Popular = productsPopular;
            this.OnSale = productsOnSale;
        }
    }
}