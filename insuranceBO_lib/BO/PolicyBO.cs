using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using insuranceDA_lib.Repositories;
using insuranceDA_lib.models;

namespace insuranceBO_lib.BO
{
    public class PolicyBO
    {
        static PolicyRepository porepo = new PolicyRepository();


        public static void RemovePolicy(string policyId)
        {
            var pol = porepo.Get(policyId);
            if (pol == null)
            {
                Console.WriteLine($"{policyId} is invalid");
            }
            else
            {
                if (porepo.DeletePolicy(pol))
                {
                    Console.WriteLine($"Policy having {policyId} is deleted");
                }
                else
                {
                    Console.WriteLine("Deletion FAILED");
                }
            }



        }

        public static void CreatePolicy(insuranceBO_lib.models.Policy policy)
        {
            insuranceDA_lib.models.Policy p = new insuranceDA_lib.models.Policy()
            {
                //CustomerId = customer.CustomerId,
                PolicyType = policy.PolicyType,
                CoverageAmount = policy.CoverageAmount,
                PremiumAmount = policy.PremiumAmount,
                ValidityStartDate = policy.ValidityStartDate,
                ValidityEndDate = policy.ValidityEndDate,
            };

            if (porepo.CreatePolicy(p))
            {
                Console.WriteLine("Policy Details are Added !");
            }
            else
            {
                Console.WriteLine("Policy Details could not be Added !");
            }
        }
        public static void ViewPolicy()
        {
            var Policy = porepo.GetPolicy();
            Console.WriteLine("{0,20}{1,20}{2,20}{3,20}{4,20} {5,20}", "policyId", "policyType", "coverageAmount", "premiumAmount", "validityStartDate", "validityEndDate");
            foreach (var policy in Policy)
            {
                Console.WriteLine($"{policy}");
            }

        }

        public static void UpdatePolicy(string PolicyId)

        {
            var po = porepo.Get(PolicyId);
            if (po == null)
            {
                Console.WriteLine($"{PolicyId} is invalid");
            }
            else
            {
                Console.WriteLine("Re-enter PolicyType, coverageAmount, premiumAmount, validityStartDate, validityEndDate,");
                insuranceDA_lib.models.Policy p = new insuranceDA_lib.models.Policy()
                {
                    PolicyId = po.PolicyId,
                    PolicyType = Console.ReadLine(),
                    CoverageAmount = Console.ReadLine(),
                    PremiumAmount = Console.ReadLine(),
                    ValidityStartDate = Console.ReadLine(),
                    ValidityEndDate = Console.ReadLine(),

                };
                if (porepo.UpdatePolicy(p))
                {
                    Console.WriteLine("Policy Details are Modified !");
                }
                else
                {
                    Console.WriteLine("Policy Details could not be Modified !");
                }
            }
        }
    }
}
