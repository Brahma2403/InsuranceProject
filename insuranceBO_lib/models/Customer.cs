using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insuranceBO_lib.models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public object CustomerID { get; internal set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
