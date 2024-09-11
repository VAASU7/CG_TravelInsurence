using System;
using System.Collections.Generic;

namespace Travel_Insurance.Model
{
    public partial class Claim1
    {
        public int ClaimId { get; set; }

        public int? PolicyId { get; set; }

        public DateTime? DateSubmitted { get; set; }

        public string? ClaimStatus { get; set; }

        public decimal? ClaimAmount { get; set; }

        public string? ClaimDetails { get; set; }

        public DateTime? DateProcessed { get; set; }

        public string? ProcessorComments { get; set; }

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

        public virtual Policy? Policy { get; set; }
    }
}
