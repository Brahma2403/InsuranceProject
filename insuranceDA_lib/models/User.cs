using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace insuranceDA_lib.models
{
    public class User
    {
        public int UserId {  get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public override string ToString()
        {
            return String.Format($"{UserId,15}{UserName,15}{Password,15}{Role,15}");
        }
    }
}
