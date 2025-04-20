using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Factory;
using E_Commerce.Repository;

namespace E_Commerce.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductFactory _productFactory;

        public ProductService(IProductRepository productRepository, IProductFactory productFactory)
        {
            _productRepository = productRepository;
            _productFactory = productFactory;
        }

        public void AddProduct(int id, string name, decimal price, double discount, string email, string phone)
        {
            var product = _productFactory.CreateProduct(id, name, price, discount, email, phone);
            _productRepository.Add(product);
        }

        public IEnumerable<Models.ProductService> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Models.ProductService GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void UpdateProduct(int id, string name, decimal price, double discount, string email, string phone)
        {
            var product = _productFactory.UpdateProduct(id, name, price, discount, email, phone);
            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Remove(id);
        }
    }
}
