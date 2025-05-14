using BabaPizza.Service;
using System;
using BabaPizza.Service;
using BabaPizza.Data;
using BabaPizza.Models;

namespace resturantBabaPizza;
class Baba_Piza
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
                case "3":break; 
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
            Console.WriteLine("📦 Product Management");
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
            }
        }
    }

    private static void AddProduct(ProductService service)
    {

        Console.WriteLine("product name:");
        var name = Console.ReadLine();
        Console.WriteLine("product price:");
        var price =decimal.Parse( Console.ReadLine());
        var product = new Product
        {
            Id=1,
            Name = name,
            Price = price
        };
        service.AddProduct(product);
        Console.WriteLine(" Product added successfully! Press Enter...");
        Console.ReadLine();
    }
}



