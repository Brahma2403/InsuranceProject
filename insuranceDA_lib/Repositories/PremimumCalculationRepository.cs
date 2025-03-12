using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using insuranceDA_lib.models;

namespace insuranceDA_lib.Repositories
{
    public class PremimumCalculationRepository : IRepositoryPremimumCalculation<PremimumCalculation>
    {
        SqlConnection con;
        public PremimumCalculationRepository()
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
        public float CalculatePremium(PremimumCalculation entity)
        {
            throw new NotImplementedException();
        }
    }
}
