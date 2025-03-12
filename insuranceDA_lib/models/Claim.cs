using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace insuranceDA_lib.models
{
   public class Claim
    {
        public int ClaimId { get; set; }
        public int PolicyId {  get; set; }  
        public decimal ClaimAmount { get; set; }    
        public string ClaimStatus {  get; set; }   
        public string SubmissionDate {  get; set; }    

      public string SettlementDate {  get; set; }

      
        public override string ToString()
        {
            return String.Format($"{ClaimId,15}{PolicyId,15}{ClaimAmount,15}{ClaimStatus,15}{SubmissionDate,15}{SettlementDate,15}");
        }
    }
}
