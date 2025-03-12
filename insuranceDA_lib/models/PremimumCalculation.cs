using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insuranceDA_lib.models
{
   public class PremimumCalculation
    {
        public int CalculationId {  get; set; }
        public int PolicyId { get; set; }
        public int CustomerId { get; set; }
        public string BasePremium { get; set; }
        public string AdjustedPremium { get; set; }

    }
}
