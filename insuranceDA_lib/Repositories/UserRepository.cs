using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using insuranceDA_lib.models;
namespace insuranceDA_lib.Repositories
{
    public class UserRepository : IRepositoryUser<User>
    {
        SqlConnection con;
        public UserRepository()
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
        public List<User> GetUserProfile()
        {
            List<User> users = new List<User>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users", con);
            SqlDataReader sqldr = cmd.ExecuteReader();
            while (sqldr.Read())
            {
                User user = new User()
                {
                    UserId = Convert.ToInt32(sqldr[0]),
                    UserName = sqldr[1].ToString(),
                    Password = sqldr[2].ToString(),
                    Role = sqldr[3].ToString()
                };
                users.Add(user);
            }
            sqldr.Close();
            return users;
        }

        public User Get(object obj)
        {
            string userid = (string)obj;
            List<User> u = GetUserProfile();
            User user = u.Where(d => 
            {
                return Convert.ToString(d.UserId) == userid;
            }).FirstOrDefault();
            return user;
        }

        public bool LoginUser(String Username, String Password)
        {
            try
            {
                User user = Get(Username);
                if (user == null)
                {
                    Console.WriteLine("User not exist");
                    return false;

                }
                else
                {
                    if (Password == user.Password)
                    {
                        Console.WriteLine($"Welcome {user.UserName}");
                        return true;

                    }
                    else
                    {
                        Console.WriteLine("Incorrect Passwoord");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception e: {ex}");
            }
            return false;
        }

        public bool RegisterUser(User entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Users values(@p1,@p2,@p3)", con);
                //cmd.Parameters.Add("@p1", entity.CustomerId);
                cmd.Parameters.Add("@p1", entity.UserName);
                cmd.Parameters.Add("@p2", entity.Password);
                cmd.Parameters.Add("@p3", entity.Role);
         
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert Operation Failed -" + ex.Message);
                b = false;
            }
            return b;
        }
    }
}
