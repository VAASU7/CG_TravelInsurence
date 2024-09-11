using System;
using System.Collections.Generic;

namespace Travel_Insurance.Model
{
    public partial class Customer
    {
        public int CustomerId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();
    }
}
