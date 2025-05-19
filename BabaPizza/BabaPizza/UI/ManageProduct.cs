using BabaPizza.Data;
using BabaPizza.Models;
using BabaPizza.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaPizza.UI
{
    public static class ManageProduct
    {
        public static async Task ManageProducts()
        {
            var context = new PizzaContext();
            var service = new ProductService(context);
            bool back = false;

            while (!back)
            {

                Console.Clear();
                Console.WriteLine(" Product Management");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. List Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Back");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await AddProduct(service);
                        break;
                    case "2":
                        await GetProductById(service);
                        break;
                    case "3":
                        await UpdateProducts(service);
                        break;
                    case "4":
                        await DeleteProduct(service);
                        break;
                    case "5": back = true; break;
                }
            }
        }

        private async static Task DeleteProduct(ProductService service)
        {
            Console.WriteLine("Enter the ID of the product you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var product = await service.GetByIdAsync(id);
                if (product != null)
                {
                    Console.WriteLine($"\nAre you sure you want to delete this product?");
                    Console.WriteLine($" {product.Id}: {product.Name} - ${product.Price}");
                    Console.Write("Type 'yes' to confirm: ");

                    string confirmation = Console.ReadLine();
                    if (confirmation?.Trim().ToLower() == "yes")
                    {
                        await service.DeleteAsync(id);
                        Console.WriteLine(" Product deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine(" Deletion canceled.");
                    }
                }
                else
                {
                    Console.WriteLine(" No product found with that ID.");
                }
            }
            else
            {
                Console.WriteLine(" Invalid input. Please enter a valid number.");
            }
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }

        private async static Task UpdateProducts(ProductService service)
        {
            Console.Write(" Enter the ID of the product you want to update: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var existingProduct = await service.GetByIdAsync(id);
                if (existingProduct != null)
                {
                    Console.WriteLine($"\nCurrent Name: {existingProduct.Name}");
                    Console.WriteLine($"Current Price: {existingProduct.Price}");

                    Console.Write("Enter new name : ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                        existingProduct.Name = newName;
                    Console.Write(" Enter new price : ");
                    string priceInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out decimal newPrice))
                        existingProduct.Price = newPrice;

                    await service.UpdateAsync(existingProduct);

                }
                else
                {
                    Console.WriteLine("No product found with that ID.");
                }
            }
            else
            {
                Console.WriteLine(" Invalid ID input.");
            }
            Console.ReadLine();
        }

        private async static Task GetProductById(ProductService service)
        {
            Console.Write(" Enter the Product ID to search: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var product = await service.GetByIdAsync(id);

                if (product != null)
                {
                    Console.WriteLine($"\n Product Found:");
                    Console.WriteLine($"ID: {product.Id}");
                    Console.WriteLine($"Name: {product.Name}");
                    Console.WriteLine($"Price: {product.Price}");
                }
                else
                {
                    Console.WriteLine(" No product found with that ID.");
                }
            }
            else
            {
                Console.WriteLine(" Invalid input. Please enter a valid number.");
            }
            Console.ReadKey();
        }

        private async static Task AddProduct(ProductService service)
        {

            Console.WriteLine("product name:");
            var name = Console.ReadLine();
            Console.WriteLine("product price:");
            var price = decimal.Parse(Console.ReadLine());
            var product = new Product
            {
                Name = name,
                Price = price
            };
            await service.AddAsync(product);
            Console.WriteLine(" Product added successfully! Press Enter...");
            Console.ReadLine();
        }
    }
}