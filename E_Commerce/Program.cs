using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Factory;
using E_Commerce.Repository;

namespace E_Commerce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProductRepository productRepository = new ProductRepository();
            IProductFactory productFactory = new ProductFactory();
            Services.ProductService productService = new Services.ProductService(productRepository, productFactory);

            AddCommands();
            bool isRunning = true;
            while (isRunning)
            {
                try
                {
                    var command = Console.ReadLine().ToLower();
                    switch (command)
                    {
                        case "a":
                            ReadProduct(productService);
                            break;
                        case "all":
                            ReadAllProducts(productService);
                            break;
                        case "y":
                            Console.Clear();
                            AddCommands();
                            break;
                        case "x":
                            isRunning = false;
                            break;
                        case "c":
                            CreateProduct(productService);
                            break;
                        case "u":
                            UpdateProduct(productService);
                            break;
                        case "d":
                            DeleteProduct(productService);
                            break;
                        default:
                            Console.WriteLine($"'{command}' is not a valid command.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void AddCommands()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("  'c'  - Create a product");
            Console.WriteLine("  'all' - Read all products");
            Console.WriteLine("  'u'  - Update a product");
            Console.WriteLine("  'd'  - Delete a product");
            Console.WriteLine("  'y'  - Clear the console");
            Console.WriteLine("  'x'  - Exit the application");
        }

        static void ReadProduct(Services.ProductService productService)
        {
            Console.WriteLine("Type a product id");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                var product = productService.GetById(id);
                if (product != null)
                {
                    DisplayProductDetails(product);
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid product id.");
            }
        }

        static void ReadAllProducts(Services.ProductService productService)
        {
            Console.WriteLine("Reading all products:");
            foreach (var product in productService.GetAllProducts())
            {
                DisplayProductDetails(product);
            }
        }

        static void CreateProduct(Services.ProductService productService)
        {
            Console.WriteLine("Type a product id");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Type a product name");
                var name = Console.ReadLine();
                Console.WriteLine("Type a product price");
                if (decimal.TryParse(Console.ReadLine(), out var price))
                {
                    Console.WriteLine("Type a discount percentage");
                    if (double.TryParse(Console.ReadLine(), out var discount))
                    {
                        Console.WriteLine("Type an email");
                        var email = Console.ReadLine();
                        Console.WriteLine("Type a phone number");
                        var phone = Console.ReadLine();

                        // Create product
                        productService.AddProduct(id, name, price, discount, email, phone);
                        Console.WriteLine($"'{name}' as product created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid discount percentage.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product price.");
                }
            }
            else
            {
                Console.WriteLine("Invalid product id.");
            }
        }

        static void UpdateProduct(Services.ProductService productService)
        {
            Console.WriteLine("Type a product id");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                var product = productService.GetById(id);
                if (product != null)
                {
                    Console.WriteLine("Reading a product:");
                    DisplayProductDetails(product);

                    Console.WriteLine("Type a product name");
                    var name = Console.ReadLine();
                    Console.WriteLine("Type a product price");
                    if (decimal.TryParse(Console.ReadLine(), out var price))
                    {
                        Console.WriteLine("Type a discount percentage");
                        if (double.TryParse(Console.ReadLine(), out var discount))
                        {
                            Console.WriteLine("Type an email");
                            var email = Console.ReadLine();
                            Console.WriteLine("Type a phone number");
                            var phone = Console.ReadLine();

                            // Update product
                            productService.UpdateProduct(id, name, price, discount, email, phone);
                            Console.WriteLine($"'{name}' as product updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid discount percentage.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid product price.");
                    }
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid product id.");
            }
        }

        static void DeleteProduct(Services.ProductService productService)
        {
            Console.WriteLine("Type a product id");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                var product = productService.GetById(id);
                if (product != null)
                {
                    Console.WriteLine("Reading a product:");
                    DisplayProductDetails(product);

                    // Confirm deletion
                    productService.DeleteProduct(id);
                    Console.WriteLine($"'{product.ProductName}' as product deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid product id.");
            }
        }

        static void DisplayProductDetails(Models.ProductService product)
        {
            Console.WriteLine($"Product: {product.ProductName}");
            Console.WriteLine($"Price: ${product.ProductPrice}");
            Console.WriteLine($"Discount: {product.Discount}%");
            Console.WriteLine($"Email: {product.Email}");
            Console.WriteLine($"Phone: {product.Phone}");
        }
    }
}
