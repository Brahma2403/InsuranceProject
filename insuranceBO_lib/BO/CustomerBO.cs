using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using insuranceDA_lib.models;
using insuranceDA_lib.Repositories;
namespace insuranceBO_lib.BO
{

    public class CustomerBO
    {
        static CustomerRepository corepo = new CustomerRepository();


        public static void AddCustomer(insuranceBO_lib.models.Customer customer)
        {
            insuranceDA_lib.models.Customer cst = new insuranceDA_lib.models.Customer()
            {
                //CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,

            };

            if (corepo.AddCustomer(cst))
            {
                Console.WriteLine("Customer Details are Added !");
            }
            else
            {
                Console.WriteLine("Customer Details could not be Added !");
            }
        }

        public static void ViewCustomers()
        {
            var Customers = corepo.GetCustomerDetails();
            Console.WriteLine("{0,10}{1,40}{2,40}{3,40}{4,40}", "CustomerId", "Name", "Email", "Phone", "Adress");
            foreach (var customer in Customers)
            {
                Console.WriteLine($"{customer}");
            }

        }


        public static void UpdateCustomer(string customerId)

        {
            var customer = corepo.Get(customerId);
            if (customer == null)
            {
                Console.WriteLine($"{customerId} is invalid");
            }
            else
            {
                Console.WriteLine("Re-enter Customer name,email,phone,address");
                insuranceDA_lib.models.Customer cst = new insuranceDA_lib.models.Customer()
                {
                    CustomerId = customer.CustomerId,
                    Name = Console.ReadLine(),
                    Email = Console.ReadLine(),
                    Phone = Console.ReadLine(),
                    Address = Console.ReadLine(),

                };
                if (corepo.UpdateCustomer(cst))
                {
                    Console.WriteLine("Customer Details are Modified !");
                }
                else
                {
                    Console.WriteLine("Customer Details could not be Modified !");
                }
            }
        }

    }
}

