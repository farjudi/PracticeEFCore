using BabaPizza.Data;
using BabaPizza.Models;
using BabaPizza.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaPizza.Service
{
    public class CustomerService : GenericService<Customer>, ICustomerService
    {
        public CustomerService(PizzaContext context) : base(context) { }
    }



















    // private readonly PizzaContext _context;



    //// public CustomerService(PizzaContext context) => _context = context;
    // public void AddCustomer(Customer customer)
    // {
    //     _context.Customers.Add(customer);
    //     _context.SaveChanges();
    // }
    // public void UpdateCustomer(Customer customer)
    // {
    //     _context.Customers.Update(customer);
    //     _context.SaveChanges();
    // }
    // public void DeleteCustomer(int  id)
    // {
    //     var customer = _context.Customers.Find(id);

    //     if(customer != null)
    //     {
    //         _context.Customers.Remove(customer);
    //         _context.SaveChanges();
    //     }
    // }

    // public Customer GetCustomerById(int id)
    // {
    //     return _context.Customers.Find(id);

    // }





}
