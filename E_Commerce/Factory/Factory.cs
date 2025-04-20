using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Models;

namespace E_Commerce.Factory
{
    public interface IProductFactory
    {
        ProductService CreateProduct(int id, string name, decimal price, Double discount, string email, string phone);
        ProductService UpdateProduct(int id, string name, decimal price, Double discount, string email, string phone);
    }
}
