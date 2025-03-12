using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using insuranceDA_lib.models;
namespace insuranceDA_lib.Repositories
{
    public class CustomerRepository : IRepositoryCustomer<Customer>
    {
        SqlConnection con;
        public CustomerRepository()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            
        }
        public string ConnectionString
        {
            get
            {
                return "Data Source=LTIN618813;Initial Catalog=project;Integrated Security=True";
            }
        }
        public bool AddCustomer(Customer entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Customer values(@p1,@p2,@p3,@p4)", con);
                //cmd.Parameters.Add("@p1", entity.CustomerId);
                cmd.Parameters.Add("@p1", entity.Name);
                cmd.Parameters.Add("@p2", entity.Email);
                cmd.Parameters.Add("@p3", entity.Phone);
                cmd.Parameters.Add("@p4", entity.Address);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert Operation Failed -"+ex.Message);
                b=false;
            }
            return b;
        }

        public Customer Get(object obj)
        {
            string customerid = (string)obj;
            List<Customer> c = GetCustomerDetails();
            Customer customers = c.Where(d =>
            {
                return Convert.ToString(d.CustomerId) == customerid;
            }).FirstOrDefault();
            return customers;
        }

        public List<Customer> GetCustomerDetails()
        {
            List<Customer> customers = new List<Customer>();
            SqlCommand cmd = new SqlCommand("Select * from customer", con);
            SqlDataReader sqldr = cmd.ExecuteReader();
            while (sqldr.Read())
            {
                Customer customer = new Customer()
                {
                    CustomerId = Convert.ToInt32(sqldr[0]),
                    Name = sqldr[1].ToString(),
                    Email = sqldr[2].ToString(),
                    Phone = sqldr[3].ToString(),
                    Address = sqldr[4].ToString(),

                };
                customers.Add(customer);
            }
                sqldr.Close();
                return customers;
            }

        public bool UpdateCustomer(Customer entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Update Customer Set Name=@p2, Email=@p3, Phone=@p4, Address=@p5 where CustomerId=@p1",con);
                cmd.Parameters.Add("@p1", entity.CustomerId);
                cmd.Parameters.Add("@p2", entity.Name);
                cmd.Parameters.Add("@p3", entity.Email);
                cmd.Parameters.Add("@p4", entity.Phone);
                cmd.Parameters.Add("@p5", entity.Address);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update Operation Failed -" + ex.Message);
                b = false;
            }
            return b;
        }

    }
}
