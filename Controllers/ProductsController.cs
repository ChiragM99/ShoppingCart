using webapi.Models;
using webapi.Interfaces;
using webapi.Implementation;
using System;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        static readonly IRepository _ProductRepo = new ProductRepository();

        public ProductsController()
        {
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _ProductRepo.GetAll();
        }

        public Product GetProduct(int id)
        {
           Product item = _ProductRepo.Get(id);
           if (item == null)
           {
               throw new HttpResponseException(HttpStatusCode.NotFound);
           }
           return item;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
           return _ProductRepo.GetAll().Where(
               p => int32.Equals(p.CategoryID, category));
        }

        public IEnumerable<Product> GetProductsBySuppler(string supplier)
        {
           return _ProductRepo.GetAll().Where(
               p => int32.Equals(p.SupplierID, supplier));
        }

        public HttpResponseMessage PostProduct(Product item)
        {
           item = _ProductRepo.Add(item);
           var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item)

           string uri = Url.Link("DefaultApi", new { id = item.Id });
           response.Headers.Location = new Uri(uri);
           return response;
           //return item;
        }

        public PutProduct(int id, Product product)
        {
           product.ProductID = id;
           if (!_ProductRepo.Update(product))
           {
               throw new HttpResponseException(HttpStatusCode.NotFound);
           }
        }

        public void DeleteProduct(int id)
        {
           Product item = _ProductRepo.Get(id);
           if (item == null)
           {
               throw new HttpResponseException(HttpStatusCode.NotFound);
           }
           _ProductRepo.Remove(id);
        }
    }
}
