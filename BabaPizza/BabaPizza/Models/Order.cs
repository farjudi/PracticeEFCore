using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaPizza.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderPlaced {  get; set; }
        public DateTime OrderFulfilled{  get; set; }
        public int CustomerId { set; get; }
        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { set; get; } = null; 



    }
}
