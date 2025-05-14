using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaPizza.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }

    }
}
