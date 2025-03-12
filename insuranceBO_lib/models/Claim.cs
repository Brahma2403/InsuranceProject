using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insuranceBO_lib.models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public int PolicyId { get; set; }
        public decimal ClaimAmount { get; set; }
        public string ClaimStatus { get; set; }
        public string SubmissionDate { get; set; }

        public string SettlementDate { get; set; }
    }
}
