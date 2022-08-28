using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatchStore.Models
{
    public class SharedProductDetail
    {
        public Product Detail { get; set; }
        public IEnumerable<Product> BestSeller { get; set; }

        public IEnumerable<Image> ImageDetail { get; set; }
        public SharedProductDetail(Product productDetail, IEnumerable<Product> productsBestSeller
            ,IEnumerable<Image> imagesProduct)
        {
            this.Detail = productDetail;
            this.BestSeller = productsBestSeller;
            this.ImageDetail = imagesProduct;
        }
    }
}