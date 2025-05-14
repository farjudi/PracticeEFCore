using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaPizza.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { set; get; }
        public Order Order { get; set; }
        public Product Product { set; get; }
    }
}
