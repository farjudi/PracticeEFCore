using BabaPizza.Service;
using System;
using BabaPizza.Service;
using BabaPizza.Data;
using BabaPizza.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BabaPizza.UI;
using System.Threading.Channels;
using System.Diagnostics.Tracing;
using BabaPizza.UI;
namespace restaurantBabaPizza;
class Baba_Pizza
{
    static async Task Main(string[] args)
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
                    await ManageProduct.ManageProducts();
                    break;

                case "2":
                    await ManageCustomer.ManageCustomers();
                    break;
                case "3":
                    await ManageOrder.ManageOrdersAsync();
                    break;
                case "4":
                    exit = true;
                    break;

            }

        }


    }




}



