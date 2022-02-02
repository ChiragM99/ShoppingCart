using System.Collections.Generic;
using System.Linq;
using webapi.Interfaces;
using webapi.Models;
using Microsoft.Extensions.DependencyInjection;
using webapi.Controllers;

namespace webapi.Implementation
{
    public class ProductRepository : IRepository
    {
        private static List<Supplier> GetSuppliers()
        {
            var _suppliers = new List<Supplier>
            {
                new Supplier {SupplierID = 1, SupplierName = "Apple"},
                new Supplier {SupplierID = 2, SupplierName = "Dell"},
                new Supplier {SupplierID = 3, SupplierName = "HP"}
            };
            return _suppliers;
        }

        private static List<Category> GetCategories()
        {
            var _categories = new List<Category>
            {
                new Category {CategoryID = 1, CategoryName = "Accessories"},
                new Category {CategoryID = 2, CategoryName = "Electronics"},
                new Category {CategoryID = 3, CategoryName = "Audio"}
            };
            return _categories;
        }


        private List<Product> _products = new List<Product>();
        private int _nextId = 1;

        public ProductRepository()
        {
            Add(new Product
            {
                ProductID = 1,
                ProductName = "Heaphones",
                CategoryID = 1,
                SupplierID = 1,
                UnitPrice = 10.00,
                //ItemID = 1,
                //UnitQuantity = 2
            });
            Add(new Product
            {
                ProductID = 2,
                ProductName = "USB Cable",
                CategoryID = 1,
                SupplierID = 1,
                UnitPrice = 4.00,
                //ItemID = 2,
                //UnitQuantity = 1
            });
            Add(new Product
            {
                ProductID = 3,
                ProductName = "Monitor",
                CategoryID = 2,
                SupplierID = 3,
                UnitPrice = 100.00,
                //ItemID = 3,
                //UnitQuantity = 1
            });
            Add(new Product
            {
                ProductID = 4,
                ProductName = "Laptop",
                CategoryID = 2,
                SupplierID = 2,
                UnitPrice = 1000.00,
                //ItemID = 4,
                //UnitQuantity = 1
            });
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.ProductID = _nextId++;
            _products.Add(item); ;
        }

        public Product Get(int id, Product item)
        {
            return _products.Find(p => p.ProductID == id);
        }

        public void Remove(Product item)
        {
            _products.RemoveAll(p => p.ProductID == item.ProductID);
        }

        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = _products.FindIndex(p => p.ProductID == item.ProductID);
            if (index == -1)
            {
                return false;
            }
            _products.RemoveAt(index);
            _products.Add(item);
            return true;
        }
    }

}