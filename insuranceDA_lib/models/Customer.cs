using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insuranceDA_lib.models
{
    public class Customer
    {
        public int CustomerId {  get; set; }
        public object CustomerID { get; internal set; }
        public string Name { get; set; }
        public string Email { get; set; }   
        public string Phone { get; set; }   
        public string Address { get; set; }

        public override string ToString()
        {
            return String.Format($"{CustomerId,12}{Name,40}{Email,40}{Phone,40}{Address,40}");
        }

    }
}
