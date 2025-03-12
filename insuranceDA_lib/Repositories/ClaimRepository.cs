using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using insuranceDA_lib.models;
namespace insuranceDA_lib.Repositories
{
    public class ClaimRepository : IRepositoryClaim<Claim>
    {
        SqlConnection con;
        public ClaimRepository()
        {
            con= new SqlConnection(ConnectionString);
            con.Open();
        }
        public string ConnectionString
        {
            get
            {
                return "Data Source=LTIN618813;Initial Catalog=project;Integrated Security=True";
            }
        }

        public List<Claim> GetClaimDetails()
        {
            List<Claim> claim = new List<Claim>();
            SqlCommand cmd = new SqlCommand("Select * from claim", con);
            SqlDataReader sqldr = cmd.ExecuteReader();
            while (sqldr.Read())
            {
                //DateTime submissionDate;
                //DateTime settlementDate;

                //if (!DateTime.TryParse(sqldr[4].ToString(), out submissionDate))
                //{
                //    Console.WriteLine("Invalid SubmissionDate format.");
                //}

                
                    Claim Claim= new Claim()
                {
                     ClaimId = Convert.ToInt32(sqldr[0]),
                     PolicyId= Convert.ToInt32(sqldr[1]),
                     ClaimAmount= Convert.ToInt32(sqldr[2]),
                     ClaimStatus = sqldr[3].ToString(),
                    
                        SubmissionDate = sqldr[4].ToString(),
                        SettlementDate = sqldr[5].ToString(),
                    };
                claim.Add(Claim);
            }
            sqldr.Close();
            return claim;

        }
        public Claim Get(object obj)
        {
            string claimid = (string)obj;
            List<Claim> c = GetClaimDetails();
            Claim claim = c.Where(d =>
            {
                return Convert.ToString(d.ClaimId) == claimid;
            }).FirstOrDefault();
            return claim;
        }

        public bool ProcessClaim(Claim entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Update Claim Set PolicyId=@p2, ClaimAmount=@p3, ClaimStatus=@p4, SubmissionDate=@p5, SettlementDate=@p6 where ClaimId=@p1", con);
                cmd.Parameters.Add("@p1", entity.ClaimId);
                cmd.Parameters.Add("@p2", entity.PolicyId);
                cmd.Parameters.Add("@p3", entity.ClaimAmount);
                cmd.Parameters.Add("@p4", entity.ClaimStatus);
                cmd.Parameters.Add("@p5", entity.SubmissionDate);
                cmd.Parameters.Add("@p6", entity.SettlementDate);
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

        public bool SubmitClaim(Claim entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Claim values(@p2,@p3,@p4,@p5,@p6)", con);
                //cmd.Parameters.Add("@p1", entity.CustomerId);
               // cmd.Parameters.Add("@p1", entity.ClaimId);
                cmd.Parameters.Add("@p2", entity.PolicyId);
                cmd.Parameters.Add("@p3", entity.ClaimAmount);
                cmd.Parameters.Add("@p4", entity.ClaimStatus);
                cmd.Parameters.Add("@p5", entity.SubmissionDate);
                cmd.Parameters.Add("@p6", entity.SettlementDate);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Submit claim Operation Failed -" + ex.Message);
                b = false;
            }
            return b;
        }
    }
}
