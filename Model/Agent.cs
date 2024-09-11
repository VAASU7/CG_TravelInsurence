using System;
using System.Collections.Generic;

namespace Travel_Insurance.Model
{
    public partial class Agent
    {
        public int AgentId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Department { get; set; }
    }
}