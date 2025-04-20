using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Models;

namespace E_Commerce.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<ProductService> _products = new List<ProductService>();

        public void Add(ProductService product)
        {
            _products.Add(product);
        }

        public ProductService GetById(int id)
        {
            return _products.FirstOrDefault(p => p.ProductId == id);
        }

        public IEnumerable<ProductService> GetAll()
        {
            return _products;
        }

        public void Update(ProductService product)
        {
            var _product = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (_product != null)
            {
                _product.ProductName = product.ProductName;
                _product.ProductPrice = product.ProductPrice;
            }
        }

        public void Remove(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
