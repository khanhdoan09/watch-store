
namespace WatchShop.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class ProductDetailAdmin
    {
        public ProductDetailAdmin()
        {
        }
        public ProductDetailAdmin(Product product, List<Image> image)
        {
            Product = product;
            ListImage = image;
        }

        public ProductDetailAdmin(Product product)
        {
            Product = product;
        }
        public Product Product { get; set; }
        public List<Image> ListImage { get; set; }


    }
}
