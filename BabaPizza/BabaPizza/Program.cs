using BabaPizza.Service;
using System;
using BabaPizza.Service;
using BabaPizza.Data;
using BabaPizza.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace restaurantBabaPizza;
class Baba_Pizza
{
    static void Main(string[] args)
    {

        bool exit = false;

        while (!exit)
        {

            Console.Clear();
            Console.WriteLine(" BabaPizza Management System");
            Console.WriteLine("1. Manage Products");
            Console.WriteLine("2. Manage Customers");
            Console.WriteLine("3. Manage Orders");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");



            switch (Console.ReadLine())
            {
                case "1":
                    ManageProducts();
                    break;

                case "2":
                    break;
                case "3": break;
                case "4":
                    exit = true;
                    break;

            }

        }


    }


    public static void ManageProducts()
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
                    AddProduct(service);
                    break;
                case "2":
                    GetProductById(service);
                    break;
                case "3":
                    UpdateProducts(service);
                    break;
                case "4":
                    DeleteProduct(service);
                    break;
                case "5": back = true; break;
            }
        }
    }

    private static void DeleteProduct(ProductService service)
    {
        Console.WriteLine("Enter the ID of the product you want to delete: ");
        if(int.TryParse(Console.ReadLine(), out int  Id))
        {
            var product= service.GetProductById(Id);
            if (product != null)
            {
                Console.WriteLine($"\nAre you sure you want to delete this product?");
                Console.WriteLine($" {product.Id}: {product.Name} - ${product.Price}");
                Console.Write("Type 'yes' to confirm: ");

                string confirmation = Console.ReadLine();
                if (confirmation?.Trim().ToLower() == "yes")
                {
                    service.DeleteProduct(Id);
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

    private static void UpdateProducts(ProductService service)
    {
        Console.Write(" Enter the ID of the product you want to update: ");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var existingProduct = service.GetProductById(id);
            if (existingProduct != null)
            {
                Console.WriteLine($"\nCurrent Name: {existingProduct.Name}");
                Console.WriteLine($"Current Price: {existingProduct.Price}");

                Console.Write("Enter new name (leave blank to keep current): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                    existingProduct.Name = newName;
                Console.Write(" Enter new price (leave blank to keep current): ");
                string priceInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out decimal newPrice))
                    existingProduct.Price = newPrice;

                service.UpdateProduct(existingProduct);

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

    private static void GetProductById(ProductService service)
    {
        Console.Write(" Enter the Product ID to search: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var product = service.GetProductById(id);

            if (product != null)
            {
                Console.WriteLine($"\n Product Found:");
                Console.WriteLine($"ID: {product.Id}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: ${product.Price}");
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

    private static void AddProduct(ProductService service)
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
        service.AddProduct(product);
        Console.WriteLine(" Product added successfully! Press Enter...");
        Console.ReadLine();
    }
}



