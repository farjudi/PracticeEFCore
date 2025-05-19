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
    public static class ManageCustomer
    {

        public static async Task ManageCustomers()
        {
            var context = new PizzaContext();
            var service = new CustomerService(context);
            bool back = false;
            while (!back)
            {

                Console.Clear();
                Console.WriteLine(" Customer Management");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. List Customer");
                Console.WriteLine("3. Update Customer");
                Console.WriteLine("4. Delete Customer");
                Console.WriteLine("5. Back");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        await AddCustomer(service);
                        break;
                    case "2":
                        await GetCustomerById(service);
                        break;
                    case "3":
                        await UpdateCustomer(service);
                        break;
                    case "4":
                        await DeleteCustomer(service);
                        break;
                    case "5": back = true; break;
                }
            }
        }

        private static async Task DeleteCustomer(CustomerService service)
        {
            Console.WriteLine("Enter the ID of the customer you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                var customer = await service.GetByIdAsync(id);
                if (customer != null)
                {
                    Console.WriteLine($"\nAre you sure you want to delete this customer?");
                    Console.WriteLine($" {customer.Id}: {customer.FirstName} - ${customer.LastName}-{customer.Address} - {customer.Phone}");
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
                    Console.WriteLine(" No product found with that ID.");

            }
            else
                Console.WriteLine("Invalid input. Please enter a valid number ");
        }

        private static async Task UpdateCustomer(CustomerService service)
        {

            Console.WriteLine("Enter the ID of the customer you want to update :");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var existingcustomer = await service.GetByIdAsync(id);
                if (existingcustomer != null)
                {
                    Console.WriteLine("befor changes");

                    Console.WriteLine($"id:{existingcustomer.Id}");
                    Console.WriteLine($"first name :{existingcustomer.FirstName}");
                    Console.WriteLine($"last name :{existingcustomer.LastName}");
                    Console.WriteLine($"address: {existingcustomer.Address}");
                    Console.WriteLine($"phone : {existingcustomer.Phone}");
                    Console.WriteLine("------------------------");

                    Console.Write("Enter new first name  ");
                    var newFirstName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newFirstName))
                        existingcustomer.FirstName = newFirstName;
                    Console.Write("Enter new  last name  : ");
                    var newLastName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newLastName))
                        existingcustomer.FirstName = newLastName;

                    Console.Write("Enter new address  : ");
                    var newAddress = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newAddress))
                        existingcustomer.Address = newAddress;

                    Console.Write("Enter new phone  : ");
                    var newPhone = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newPhone))
                        existingcustomer.Phone = newPhone;

                    await service.UpdateAsync(existingcustomer);

                }
                else
                {
                    Console.WriteLine("No customer found with that ID.");
                }


            }
            else Console.WriteLine(" Invalid ID input.");
            Console.ReadKey();
        }

        private async static Task GetCustomerById(CustomerService service)
        {
            Console.WriteLine(" Enter the Customer ID to search");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                var customer = await service.GetByIdAsync(id);
                if (customer != null)
                {
                    Console.WriteLine("customer found");
                    Console.WriteLine($"Id :{customer.Id}");
                    Console.WriteLine($"First name: {customer.FirstName} ");
                    Console.WriteLine($"Last name :{customer.LastName}");
                    Console.WriteLine($"Address:{customer.Address}");
                    Console.WriteLine($"Phone:{customer.Phone}");
                }
                else
                {
                    Console.WriteLine(" No customer found with that ID.");

                }
            }
            else
            {
                Console.WriteLine(" Invalid input. Please enter a valid number.");
            }
            Console.ReadKey();
        }

        private async static Task AddCustomer(CustomerService service)
        {
            Console.WriteLine("Customer name:");
            var name = Console.ReadLine();
            Console.WriteLine("Customer Last name :");
            var lastName = Console.ReadLine();
            Console.WriteLine("Customer Address :");
            var address = Console.ReadLine();
            Console.WriteLine("Customer Phone: ");
            var phone = Console.ReadLine();


            var customer = new Customer
            {
                FirstName = name,
                LastName = lastName,
                Address = address,
                Phone = phone
            };
            await service.AddAsync(customer);
            Console.WriteLine(" customer added successfully! Press Enter...");
            Console.ReadLine();
        }
    }
}
