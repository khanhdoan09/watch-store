using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Controllers.API
{
    public class ProductController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();
        
        public IHttpActionResult GetProductByBrand(string bid)
        {
            IList<Product> products = db.Products.Where(p=>p.Brand.Equals(bid)).ToList();
            return Ok(products);
        }
        public IHttpActionResult GetProductByGender(string gen)
        {
            IList<Product> products = db.Products.Where(p => p.Gender.Equals(gen)).ToList();
            return Ok(products);
        }
        public IHttpActionResult GetProductDetail(string pid)
        {
            Product pu = db.Products.Where(p => p.Id.Equals(pid)).FirstOrDefault();
            return Ok(pu);
        }

        public IHttpActionResult GetProductByBestSeller()
        {
            IList<Product> products = db.Products.OrderByDescending(p => p.Import - p.Stock).Take(4).ToList();
            return Ok(products);
        }
        public IHttpActionResult GetProductByOnSale(float numSale)
        {
            IList<Product> products = db.Products.OrderByDescending(p =>p.Discount).Take(12).ToList();
            return Ok(products);
        }
        public IHttpActionResult GetProductByBestDeal(float deal)
        {
            IList<Product> products = db.Products.OrderByDescending(p => p.Discount).ToList();
            return Ok(products);
        }
        public IHttpActionResult GetProductByRich(float rich)
        {
            IList<Product> products = (IList<Product>)db.Products.OrderByDescending(p => p.Price).ToList();
            return Ok(products);
        }

        // dang gap loi
        public IHttpActionResult GetProductByNewArrival(DateTime da)
        {
           
            IList<Product> products = db.Products.OrderByDescending(p => p.UpdateDate).Take(12).ToList();
            return Ok(products);

        }
        public IHttpActionResult GetProductByPopular(int popular)
        {
            IList<Product> products = db.Products.OrderByDescending(p => p.Import).Take(12).ToList();
            return Ok(products);
        }
        public IHttpActionResult GetProductByOrigin(string origin)
        {
            IList<Product> products = db.Products.Where(p => p.Origin.Equals(origin)).ToList();
            return Ok(products);
        }
        public IHttpActionResult GetProductByWaterproof(string waterproof)
        {
            IList<Product> products = db.Products.Where(p => p.Waterproof.Equals(waterproof)).ToList();
            return Ok(products);
        }
        //CHUA LOAD 
        public IHttpActionResult GetProductByPrice(double price)
        {
            IList<Product> products = db.Products.Where(p => p.Price >= price).ToList();
            return Ok(products);
        }
        // tim kiem san pham 
        public IHttpActionResult GetProductByName(string txtName)
        {
            IList<Product> products = db.Products.Where(p => p.Name.Contains(txtName)).ToList();
            return Ok(products);
        }
        
    }
}
