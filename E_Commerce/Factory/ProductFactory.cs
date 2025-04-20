using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Models;

namespace E_Commerce.Factory
{
    public class ProductFactory : IProductFactory
    {
        public ProductService CreateProduct(int id, string name, decimal price, Double discount, string email, string phone)
        {
            return new ProductService(id, name, price, discount, email, phone);
        }

        public ProductService UpdateProduct(int id, string name, decimal price, double discount, string email, string phone)
        {
            return new ProductService(id, name, price, discount, email, phone);
        }
    }
}
