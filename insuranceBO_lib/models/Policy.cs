using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insuranceBO_lib.models
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyType { get; set; }
        public string CoverageAmount { get; set; }

        public string PremiumAmount { get; set; }
        public string ValidityStartDate { get; set; }
        public string ValidityEndDate { get; set; }



    }
}
