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
    public class OrderService : GenericService<Order>, IOrderService

    {
        public OrderService(PizzaContext context) : base(context)
        {

        }
    }
}
