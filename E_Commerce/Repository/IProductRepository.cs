using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Models;

namespace E_Commerce.Repository
{
    public interface IProductRepository
    {
        void Add(ProductService product);
        ProductService GetById(int id);
        IEnumerable<ProductService> GetAll();
        void Update(ProductService product);
        void Remove(int id);
    }
}
