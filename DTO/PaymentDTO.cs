namespace Travel_Insurance.DTO
{
    using System;

    public class PaymentDTO
    {
        public int PaymentID { get; set; }
        public int ClaimID { get; set; }
        public DateTime PaymentDate { get; set; }
        public double AmountPaid { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionID { get; set; }

    }
}