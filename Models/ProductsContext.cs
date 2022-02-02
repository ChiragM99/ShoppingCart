using System;
using webapi.Models;
using webapi.Implementation;
using webapi.Interfaces;


namespace webapi.Controllers
{
    [RoutePrefix("api/ProductController")]
    public class ProductController : ApiController
    {
        static readonly IRepository repostiory = new ProductRepository();

        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAll();
        }

        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return repository.GetAll().Where(
                p => int32.Equals(p.CategoryID, category));
        }

        public IEnumerable<Product> GetProductsBySuppler(string supplier)
        {
            return repository.GetAll().Where(
                p => int32.Equals(p.SupplierID, supplier));
        }

        public HttpResponseMessage PostProduct(Product item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Prouct>(HttpStatusCode.Created, item)

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
            //return item;
        }

        public PutProduct(int id, Product product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteProduct(int id)
        {
            Product item = repostiory.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repostiory.Remove(id);
        }
    }
}