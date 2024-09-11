using System;
using System.Collections.Generic;

namespace Travel_Insurance.Model
{
    public partial class Payment
    {
        public int PaymentId { get; set; }

        public int? ClaimId { get; set; }

        public DateTime? PaymentDate { get; set; }

        public decimal? AmountPaid { get; set; }

        public string? PaymentMethod { get; set; }

        public string? TransactionId { get; set; }

        public virtual Claim1? Claim { get; set; }
    }
}