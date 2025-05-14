using BabaPizza.Data;
using BabaPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaPizza.Service
{
    public class ProductService
    {
        private readonly PizzaContext _context;

        public ProductService(PizzaContext context) => _context = context;

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

        }



        public Product? GetProductById(int id)
        {
            return _context.Products.Find(id);
        }
    }
}
