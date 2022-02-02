using webapi.Models;
using webapi.Controllers;
using webapi.Implementation;



namespace webapi.Interfaces
{
    public interface IRepository
    {
        public IEnumerable<Product> GetAll();
        public void Add(Product item);
        public Product Get(int id, Product item);
        public void Remove(Product item);
        public bool Update(Product item);
    }
}
