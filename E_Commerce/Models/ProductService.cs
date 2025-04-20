using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class ProductService
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public double Discount { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public ProductService(int id, string name, decimal price, double discount, string email, string phone)
        {


            ProductId = id;
            ProductName = name;
            ProductPrice = price;
            Discount = discount;
            Email = email;
            Phone = phone;

        }
    }
}
