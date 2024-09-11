using System;
using System.Collections.Generic;

namespace Travel_Insurance.Model
{
    public partial class Policy
    {
        public int PolicyId { get; set; }

        public int? CustomerId { get; set; }

        public string? PolicyNumber { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? CoverageDetails { get; set; }

        public decimal? PremiumAmount { get; set; }

        public virtual ICollection<Claim1> Claims { get; set; } = new List<Claim1>();

        public virtual Customer? Customer { get; set; }
    }
}