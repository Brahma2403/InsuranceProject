using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using insuranceDA_lib.models;
namespace insuranceDA_lib.Repositories
{
    public class PolicyRepository : IRepositoryPolicy<Policy>
    {
        SqlConnection con;
        public PolicyRepository()
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
        public bool CreatePolicy(Policy entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Policy values(@p1,@p2,@p3,@p4,@p5)", con);
                //cmd.Parameters.Add("@p1", entity.CustomerId);
                cmd.Parameters.Add("@p1", entity.PolicyType);
                cmd.Parameters.Add("@p2", entity.CoverageAmount);
                cmd.Parameters.Add("@p3", entity.PremiumAmount);
                cmd.Parameters.Add("@p4", entity.ValidityStartDate);
                cmd.Parameters.Add("@p5", entity.ValidityEndDate);
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

        public bool DeletePolicy(Policy entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from policy Where policyId=@p1", con);
                //cmd.Parameters.Add("@p1", entity.CustomerId);
                cmd.Parameters.Add("@p1", entity.PolicyId);
                
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Operation Failed -" + ex.Message);
                b = false;
            }
            return b;


        }

        public List<Policy> GetPolicy()
        {
            List<Policy> policy= new List<Policy>();
            SqlCommand cmd = new SqlCommand("Select * from policy", con);
            SqlDataReader sqldr = cmd.ExecuteReader();
            while (sqldr.Read())
            {
                Policy Policy = new Policy()
                {
                    PolicyId = Convert.ToInt32(sqldr[0]),
                    PolicyType= sqldr[1].ToString(),
                    PremiumAmount = sqldr[2].ToString(),
                    CoverageAmount = sqldr[3].ToString(),
                    ValidityStartDate = sqldr[4].ToString(),
                    ValidityEndDate = sqldr[5].ToString()

                };
                policy.Add(Policy);
            }
            sqldr.Close();
            return policy;
        }

        public bool UpdatePolicy(Policy entity)
        {
      
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Update Policy Set PolicyType=@p2, CoverageAmount=@p3, PremiumAmount=@p4, validityStartDate=@p5, validityEndDate=@p6 where PolicyId=@p1", con);
                cmd.Parameters.Add("@p1", entity.PolicyId);
                cmd.Parameters.Add("@p2", entity.PolicyType);
                cmd.Parameters.Add("@p3", entity.CoverageAmount);
                cmd.Parameters.Add("@p4", entity.PremiumAmount);
                cmd.Parameters.Add("@p5", entity.ValidityStartDate);
                cmd.Parameters.Add("@p6", entity.ValidityEndDate);

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
        

        public Policy Get(object id)
        {
            int policyId;
            if (id is int)
            {
                policyId = (int)id;
            }
            else if (id is string idString && int.TryParse(idString, out int parsedId))
            {
                policyId = parsedId;
            }
            else
            {
                // Handle the case where id cannot be converted to int
                throw new ArgumentException("Invalid policy ID");
            }
                List<Policy> policies = GetPolicy();
            Policy policy = policies.Where(p => p.PolicyId == policyId).FirstOrDefault();
            return policy;

        }
    }
}

