using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using insuranceDA_lib.models;
using insuranceDA_lib.Repositories;

namespace insuranceBO_lib.BO
{
   public class ClaimBO
    {
        static ClaimRepository crepo=new ClaimRepository();
        public static void SubmitClaim(insuranceBO_lib.models.Claim claim)
        {
            insuranceDA_lib.models.Claim cs = new insuranceDA_lib.models.Claim()
            {
                ClaimId=claim.ClaimId,
                PolicyId = claim.PolicyId,
                ClaimStatus = claim.ClaimStatus,
                ClaimAmount = claim.ClaimAmount,
                SubmissionDate = claim.SubmissionDate,
                SettlementDate = claim.SettlementDate,
            };

            if(crepo.SubmitClaim(cs))
            {
                Console.WriteLine("Claim Details are Submitted !");
            }
            else
            {
                Console.WriteLine("Claim Details could not be submitted !");
            }
        }

        public static void getClaimDetails()
        {
            var clm = crepo.GetClaimDetails();
            Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}{5,15}", "claimId", "PolicyId", "claimAmount", "claimStatus", "SubmissionDate", "settlementDate");
            foreach (var cm in clm)
            {
                Console.WriteLine($"{cm}");
            }

        }
        public static void ProcessClaim(string claimId)

        {
            var claim = crepo.Get(claimId);
            if (claim == null)
            {
                Console.WriteLine($"{claimId} is invalid");
            }
            else
            {
                Console.WriteLine("Re-enter PolicyId,ClaimAmount,ClaimStatus,SubmissionDate,SettlementDate");
                insuranceDA_lib.models.Claim c = new insuranceDA_lib.models.Claim()
                {
                    ClaimId = claim.ClaimId,
                    PolicyId = Convert.ToInt32(Console.ReadLine()),
                    ClaimAmount = Convert.ToInt32(Console.ReadLine()),
                    ClaimStatus = Console.ReadLine(),
                    SubmissionDate =Convert.ToString( Console.ReadLine()),
                    SettlementDate = Convert.ToString(Console.ReadLine()),

                };
                if (crepo.ProcessClaim(c))
                {
                    Console.WriteLine("Claim Details are Processed!");
                }
                else
                {
                    Console.WriteLine("Claim Details could not be Processed!");
                }
            }
        }

    }
}
