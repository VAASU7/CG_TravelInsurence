 using System;
namespace Travel_Insurance.DTO
{
   

    public class PolicyDTO
    {
        public int PolicyID { get; set; }
        public int CustomerID { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CoverageDetails { get; set; }
        public decimal PremiumAmount { get; set; }

    }
}