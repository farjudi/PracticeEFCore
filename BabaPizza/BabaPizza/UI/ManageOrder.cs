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
    public static class ManageOrder
    {
        public static async Task ManageOrdersAsync()
        {
            var context = new PizzaContext();
            var service = new OrderService(context);

            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine(" Orders Management");
                Console.WriteLine("1. Add Orders");
                Console.WriteLine("2. List Orders");
                Console.WriteLine("3. Update Orders");
                Console.WriteLine("4. Delete Orders");
                Console.WriteLine("5. Back");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await AddOrderAsync(service);
                        break;
                    case "2":
                        await GetOrderByIdAsync(service);

                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                }



            }



        }
        // There is a problem, fix it.
        private static async Task GetOrderByIdAsync(OrderService service)
        {
            Console.Write(" Enter the order ID to search: ");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                var order = await service.GetByIdAsync(id);
                if (order != null)
                {
                    Console.WriteLine($"Customer found");
                    Console.WriteLine($"Id :{order.Id}");
                    Console.WriteLine($"Order placed :{order.OrderPlaced}");
                    Console.WriteLine($"Order fulfilled{order.OrderFulfilled}");
                    Console.WriteLine($"");
                    // اینو چ کنم ؟؟
                    if (order.Customer != null)
                    {
                        Console.WriteLine($"Customer name: {order.Customer.FirstName}");
                    }
                    else Console.WriteLine("No customer info available.");
                }
                else
                    Console.WriteLine("Order not found.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number");
            }

        }

        private static async Task AddOrderAsync(OrderService service)
        {
            Console.Write("Order placed (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out var orderPlaced))
            { Console.WriteLine("Invalid date format."); return; }

            Console.Write("Order fulfilled (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out var orderFulfilled))
            {
                Console.WriteLine("Invalid data format "); return;
            }
            Console.Write("Customer Id: ");
            if (!int.TryParse(Console.ReadLine(), out var customerId))
            {
                Console.WriteLine("Invalid customer ID.");
                return;
            }

            var newOrder = new Order
            {
                OrderPlaced = orderPlaced,
                OrderFulfilled = orderFulfilled,
                CustomerId = customerId
            };
            await service.AddAsync(newOrder);
            Console.WriteLine("Order added successfully!");


            //چطور کاستومتر رو بدم خودش رو و اطلاعات رو ؟؟
        }
    }



}
