using System;

namespace Travel_Insurance.DTO
{
    public class Claim1DTO
    {
        public int ClaimID { get; set; }
        public int PolicyID { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string ClaimStatus { get; set; }
        public decimal ClaimAmount { get; set; }
        public string ClaimDetails { get; set; }
        public DateTime? DateProcessed { get; set; }
        public string ProcessorComments { get; set; }

        
    }
}