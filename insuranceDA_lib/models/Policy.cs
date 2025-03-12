using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace insuranceDA_lib.models
{
    public class Policy
    {
        public int PolicyId {  get; set; }
        public string PolicyType { get; set; }
        public string CoverageAmount { get; set; }
        
        public string PremiumAmount { get; set; }
        public string ValidityStartDate { get; set; }
        public string ValidityEndDate { get; set; }
        public override string ToString()
        {
            return String.Format($"{PolicyId,15}{PolicyType,20}{CoverageAmount,20}{PremiumAmount,20}{ValidityStartDate,20}{ValidityEndDate,20}");
        }



    }
}
